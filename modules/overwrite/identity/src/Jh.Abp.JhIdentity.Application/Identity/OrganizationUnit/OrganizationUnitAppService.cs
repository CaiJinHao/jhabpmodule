using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using Jh.Abp.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;

namespace Jh.Abp.JhIdentity
{
    /*
	 顶级和顶级不能修改，可以有多个顶级，顶级一旦创建不能更改
	 */

    public class OrganizationUnitAppService
		: CrudApplicationService<OrganizationUnit, OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>,
		IOrganizationUnitAppService
	{
        protected JhIdentityUserManager JhIdentityUserManager => LazyServiceProvider.LazyGetRequiredService<JhIdentityUserManager>();
        protected IJhIdentityRoleRepository IdentityRoleRepository=>LazyServiceProvider.LazyGetRequiredService<IJhIdentityRoleRepository>();
        protected Volo.Abp.Identity.IOrganizationUnitRepository AbpOrganizationUnitsRepository => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IOrganizationUnitRepository>();
        private readonly IOrganizationUnitRepository OrganizationUnitRepository;
		private JhOrganizationUnitManager OrganizationUnitManager => LazyServiceProvider.LazyGetRequiredService<JhOrganizationUnitManager>();
        protected OrganizationUnitExtensionManager organizationUnitExtensionManager => LazyServiceProvider.LazyGetRequiredService<OrganizationUnitExtensionManager>();
        public OrganizationUnitAppService(IOrganizationUnitRepository repository) : base(repository)
        {
            OrganizationUnitRepository = repository;

            CreatePolicyName = JhIdentityPermissions.OrganizationUnits.Create;
            UpdatePolicyName = JhIdentityPermissions.OrganizationUnits.Update;
            DeletePolicyName = JhIdentityPermissions.OrganizationUnits.Delete;
            GetPolicyName = JhIdentityPermissions.OrganizationUnits.Detail;
            GetListPolicyName = JhIdentityPermissions.OrganizationUnits.Default;
            BatchDeletePolicyName = JhIdentityPermissions.OrganizationUnits.BatchDelete;
        }

        protected virtual Func<IQueryable<OrganizationUnit>, IQueryable<OrganizationUnit>> GetQueryAction(OrganizationUnitRetrieveInputDto input)
        {
            return entity =>
            {
                if (!string.IsNullOrEmpty(input.Code))
                {
                    entity = entity.Where(a=>a.Code.StartsWith(input.Code));
                }
                entity = OrganizationUnitRepository.GetByLeaderAsync(entity, input.LeaderId, input.LeaderName).Result;
                return entity;
            };
        }

        protected virtual async Task MapToOrganizationUnitDto(OrganizationUnitDto organizationUnitDto)
        {
            var entity = await organizationUnitExtensionManager.GetAsync(organizationUnitDto.Id);
            if (entity == null)
            {
                return;
            }
            organizationUnitDto.LeaderId = entity.LeaderId;
            organizationUnitDto.LeaderName = await JhIdentityUserManager.GetIdentityUserNameAsync(entity.LeaderId);
            organizationUnitDto.LeaderType = entity.LeaderType;
        }

        public override async Task<OrganizationUnitDto> GetAsync(Guid id)
        {
            var OrganizationUnitDto = await base.GetAsync(id, true);
            await MapToOrganizationUnitDto(OrganizationUnitDto);
            return OrganizationUnitDto;
        }

        public override async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            var pageResult = await base.GetListAsync(input, queryAction: GetQueryAction(input));
            foreach (var item in pageResult.Items)
            {
                await MapToOrganizationUnitDto(item);
            }
            return pageResult;
        }

        public override async Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateInputDto input)
		{
            await CheckCreatePolicyAsync();
            var organizationUnit = new OrganizationUnit(GuidGenerator.Create(), input.DisplayName, input.ParentId, CurrentUser.TenantId);
            if (input.RoleIds != null)
            {
                foreach (var item in input.RoleIds)
                {
                    organizationUnit.AddRole(item);
                }
            }
            
            await OrganizationUnitManager.CreateAsync(organizationUnit);
            await organizationUnitExtensionManager.CreateAsync(new OrganizationUnitExtension(organizationUnit.Id, input.LeaderId, input.LeaderType));
            return MapToGetOutputDto(organizationUnit);
		}

        public override async Task DeleteAsync(Guid id)
        {
            await CheckDeletePolicyAsync();
            await OrganizationUnitManager.DeleteAsync(id);//自动禁用下级
        }

        public override async Task DeleteAsync(Guid[] keys)
        {
            await CheckDeletePolicyAsync();
            foreach (var item in keys)
            {
                await OrganizationUnitManager.DeleteAsync(item);//自动禁用下级
            }
        }

        protected virtual async Task DeleteAsync(OrganizationUnitDeleteInputDto deleteInputDto)
        {
            await CheckDeletePolicyAsync();
            var query = await CreateFilteredQueryAsync(deleteInputDto);
            foreach (var item in query.ToArray())
            {
				await OrganizationUnitManager.DeleteAsync(item.Id);//自动禁用下级
			}
		}

        public override async Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateInputDto input)
        {
            await CheckUpdatePolicyAsync();
            var entity = await crudRepository.GetAsync(id);
            entity.ConcurrencyStamp = input.ConcurrencyStamp;
			entity.DisplayName = input.DisplayName;
            if (input.RoleIds != null)
            {
                entity.Roles.Clear();
                foreach (var item in input.RoleIds)
                {
                    entity.AddRole(item);
                }
            }
            await crudRepository.UpdateAsync(entity);
            await organizationUnitExtensionManager.UpdateAsync(id, input.LeaderId, input.LeaderType);
            await CurrentUnitOfWork.SaveChangesAsync();//目的是在移动之前要保存组织信息
            await OrganizationUnitManager.MoveAsync(id, input.ParentId);
			return await MapToGetOutputDtoAsync(entity);
        }

		public virtual async Task RecoverAsync(Guid id)
		{
            await CheckPolicyAsync(JhIdentityPermissions.OrganizationUnits.Recover);
            using (DataFilter.Disable<ISoftDelete>())
            {
                foreach (var item in await GetParentsAsync(id, true))
                {
                    //启用得时候需要将组织角色中间表关系添加上，或者由前端自行编辑添加
                    item.IsDeleted = false;
                    item.DeleterId = CurrentUser.Id;
                    item.DeletionTime = Clock.Now;
                    await crudRepository.UpdateAsync(item);
                }
            }
		}

        protected virtual async Task<List<OrganizationUnit>> GetParentsAsync(Guid? id, bool isDeleted = true)
        {
            var data = new List<OrganizationUnit>();
            async Task GetParent(Guid parenttid)
            {
                var dbset = await crudRepository.GetQueryableAsync(true, isTracking: IsTracking);
                var root = dbset.FirstOrDefault(a => a.Id == (Guid)parenttid && a.IsDeleted == isDeleted);
                if (root != null)
                {
                    data.Add(root);
                    if (root.ParentId.HasValue)
                    {
                        await GetParent((Guid)root.ParentId);
                    }
                }
            }
            if (id.HasValue)
            {
                await GetParent((Guid)id);
            }
            return data;
        }

		public virtual async Task<ListResultDto<TreeAntdDto>> GetOrganizationTreeAsync()
		{
            var resutlMenus = await OrganizationUnitRepository.GetTreeAntdDtosAsync();
            var data= await UtilTree.GetTreeByAntdAsync(resutlMenus);
            return new ListResultDto<TreeAntdDto>(data);
        }

        public virtual async Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid organizationUnitId)
        {
            await CheckGetListPolicyAsync();
            var org = await GetEntityByIdAsync(organizationUnitId);
            var entities = await AbpOrganizationUnitsRepository.GetRolesAsync(org);

            var dtos = new List<IdentityRoleDto>();
            foreach (var entity in entities)
            {
                dtos.Add(ObjectMapper.Map<IdentityRole, IdentityRoleDto>(entity));
            }
            return new ListResultDto<IdentityRoleDto>(dtos);
        }

        public virtual async Task<ListResultDto<IdentityUserDto>> GetMembersAsync(Guid organizationUnitId)
        {
            await CheckGetListPolicyAsync();
            var org = await GetEntityByIdAsync(organizationUnitId);
            var entities = await AbpOrganizationUnitsRepository.GetMembersAsync(org);
            var dtos = new List<IdentityUserDto>();
            foreach (var entity in entities)
            {
                dtos.Add(ObjectMapper.Map<IdentityUser, IdentityUserDto>(entity));
            }
            return new ListResultDto<IdentityUserDto>(dtos);
        }

        public virtual async Task CreateByRoleAsync(Guid roleId)
        {
            await CheckCreatePolicyAsync();
            var datas = await OrganizationUnitRepository.GetListAsync(true);
            foreach (var item in datas)
            {
                if (item.Roles.Any(r => r.OrganizationUnitId == item.Id && r.RoleId == roleId))
                {
                    continue;
                }
                item.AddRole(roleId);
            }
        }

        public virtual async Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name)
        {
            var datas = await OrganizationUnitRepository.GetQueryableAsync(true, isTracking: IsTracking);
            return new ListResultDto<OptionDto<Guid>>(datas.Select(a => new OptionDto<Guid> { Label = a.DisplayName, Value = a.Id }).ToList());
        }

        public virtual async Task<ListResultDto<OptionDto<Guid>>> GetRoleOptionsAsync(Guid[] orgIds)
        {
            var roles = await OrganizationUnitRepository.GetRolesAsync(orgIds);
            var dataOptions = roles.Select(role => new OptionDto<Guid>() { Label = role.Name, Value = role.Id });
            return new ListResultDto<OptionDto<Guid>>(dataOptions.Distinct().ToList());
        }
    }
}
