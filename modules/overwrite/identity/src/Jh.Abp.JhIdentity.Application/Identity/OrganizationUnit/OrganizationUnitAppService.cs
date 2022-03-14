using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    /*
	 �����Ͷ��������޸ģ������ж������������һ���������ܸ���
	 */

    public class OrganizationUnitAppService
		: CrudApplicationService<OrganizationUnit, OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>,
		IOrganizationUnitAppService
	{
        protected IJhIdentityRoleRepository identityRoleRepository=>LazyServiceProvider.LazyGetRequiredService<IJhIdentityRoleRepository>();
        protected Volo.Abp.Identity.IOrganizationUnitRepository organizationUnitsRepository => LazyServiceProvider.LazyGetRequiredService<Volo.Abp.Identity.IOrganizationUnitRepository>();
        private readonly IOrganizationUnitRepository OrganizationUnitRepository;
		private readonly IOrganizationUnitDapperRepository OrganizationUnitDapperRepository;
		private JhOrganizationUnitManager organizationUnitManager => LazyServiceProvider.LazyGetRequiredService<JhOrganizationUnitManager>();
        public OrganizationUnitAppService(IOrganizationUnitRepository repository, IOrganizationUnitDapperRepository organizationunitDapperRepository) : base(repository)
        {
            OrganizationUnitRepository = repository;
            OrganizationUnitDapperRepository = organizationunitDapperRepository;

            CreatePolicyName = JhIdentityPermissions.OrganizationUnits.Create;
            UpdatePolicyName = JhIdentityPermissions.OrganizationUnits.Update;
            DeletePolicyName = JhIdentityPermissions.OrganizationUnits.Delete;
            GetPolicyName = JhIdentityPermissions.OrganizationUnits.Detail;
            GetListPolicyName = JhIdentityPermissions.OrganizationUnits.Default;
            BatchDeletePolicyName = JhIdentityPermissions.OrganizationUnits.BatchDelete;
        }

        public override async Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            IsTracking = true;
            if (!string.IsNullOrEmpty(input.Code))
            {
                input.MethodInput = new MethodDto<OrganizationUnit>()
                {
                    QueryAction = entity => entity.Where(a => a.Code.StartsWith(input.Code))
                };
            }
            return await base.GetListAsync(input);
        }

        public override async Task<OrganizationUnitDto> CreateAsync(OrganizationUnitCreateInputDto input)
		{
            await CheckCreatePolicyAsync();
			var organizationUnit = new OrganizationUnit(GuidGenerator.Create(), input.DisplayName, input.ParentId, CurrentUser.TenantId);
			organizationUnit.ConcurrencyStamp = input.ConcurrencyStamp;
            input.RoleIds = await GetAllRoleIdAsync();//������еĽ�ɫ������֯
            if (input.RoleIds != null)
            {
                foreach (var item in input.RoleIds)
                {
                    organizationUnit.AddRole(item);
                }
            }
            if (input.ExtraProperties.Count > 0)
            {
                foreach (var item in input.ExtraProperties)
                {
                    organizationUnit.SetProperty(item.Key, item.Value);
                }
            }
            await organizationUnitManager.CreateAsync(organizationUnit);
            return MapToGetOutputDto(organizationUnit);
		}

        public override async Task DeleteAsync(Guid id)
        {
            await CheckDeletePolicyAsync();
            await organizationUnitManager.DeleteAsync(id);//�Զ������¼�
        }

        public override async Task DeleteAsync(Guid[] keys)
        {
            await CheckDeletePolicyAsync();
            foreach (var item in keys)
            {
				await organizationUnitManager.DeleteAsync(item);//�Զ������¼�
			}
		}

        protected virtual async Task DeleteAsync(OrganizationUnitDeleteInputDto deleteInputDto)
        {
            await CheckDeletePolicyAsync();
            var query = await CreateFilteredQueryAsync(deleteInputDto);
            foreach (var item in query.ToArray())
            {
				await organizationUnitManager.DeleteAsync(item.Id);//�Զ������¼�
			}
		}

        public override async Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateInputDto input)
        {
            await CheckUpdatePolicyAsync();
            var entity = await crudRepository.FindAsync(id);
			entity.DisplayName = input.DisplayName;
            if (input.RoleIds != null)
            {
                entity.Roles.Clear();
                foreach (var item in input.RoleIds)
                {
                    entity.AddRole(item);
                }
            }
            if (input.ExtraProperties.Count > 0)
            {
                foreach (var item in input.ExtraProperties)
                {
                    entity.SetProperty(item.Key, item.Value);
                }
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            await organizationUnitManager.MoveAsync(id, input.ParentId);
			return await MapToGetOutputDtoAsync(entity);
        }

		public virtual async Task RecoverAsync(Guid id)
		{
            await CheckPolicyAsync(JhIdentityPermissions.OrganizationUnits.Recover);
            using (DataFilter.Disable<ISoftDelete>())
            {
                foreach (var item in await GetParentsAsync(id, true))
                {
                    item.IsDeleted = false;
                    item.DeleterId = CurrentUser.Id;
                    item.DeletionTime = Clock.Now;
                }
            }
		}

        protected virtual async Task<List<OrganizationUnit>> GetParentsAsync(Guid? id, bool isDeleted = true)
        {
            var data = new List<OrganizationUnit>();
            async Task GetParent(Guid parenttid)
            {
                var dbset = await crudRepository.GetQueryableAsync(true);
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

		public virtual async Task<List<TreeDto>> GetOrganizationTreeAsync()
		{
            await CheckGetListPolicyAsync();
            var resutlMenus = await (await OrganizationUnitRepository.GetQueryableAsync()).AsNoTracking().Select(a =>
               new TreeDto()
               {
                   id = a.Id.ToString(),
                   parent_id = a.ParentId.ToString(),
                   title = a.DisplayName,
                   value = a.Id.ToString(),
                   sort = a.CreationTime.ToString("yyyyMMddHHmmssfff"),
                   obj = a
               }
           ).ToListAsync();
            return await UtilTree.GetMenusTreeAsync(resutlMenus);
        }

        public virtual async Task<List<IdentityRoleDto>> GetRolesAsync(Guid organizationUnitId)
        {
            await CheckGetListPolicyAsync();
            var org = await GetEntityByIdAsync(organizationUnitId);
            var entities = await organizationUnitsRepository.GetRolesAsync(org);

            var dtos = new List<IdentityRoleDto>();
            foreach (var entity in entities)
            {
                dtos.Add(ObjectMapper.Map<IdentityRole, IdentityRoleDto>(entity));
            }
            return dtos;

        }

        public virtual async Task<List<IdentityUserDto>> GetMembersAsync(Guid organizationUnitId)
        {
            await CheckGetListPolicyAsync();
            var org = await GetEntityByIdAsync(organizationUnitId);
            var entities = await organizationUnitsRepository.GetMembersAsync(org);
            var dtos = new List<IdentityUserDto>();
            foreach (var entity in entities)
            {
                dtos.Add(ObjectMapper.Map<IdentityUser, IdentityUserDto>(entity));
            }
            return dtos;
        }

        private async Task<Guid[]> GetAllRoleIdAsync()
        {
            return (await identityRoleRepository.GetQueryableAsync(false)).AsNoTracking().Select(a=>a.Id).ToArray();
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
    }
}
