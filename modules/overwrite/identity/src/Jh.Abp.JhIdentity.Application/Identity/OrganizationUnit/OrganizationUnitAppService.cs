using Jh.Abp.Application;
using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    /*
	 顶级和顶级不能修改，可以有多个顶级，顶级一旦创建不能更改
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
        }

        public override Task<PagedResultDto<OrganizationUnitDto>> GetListAsync(OrganizationUnitRetrieveInputDto input, string methodStringType = "Contains", bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            IsTracking = true;
            if (!string.IsNullOrEmpty(input.Code))
            {
                input.MethodInput = new MethodDto<OrganizationUnit>()
                {
                    QueryAction = entity => entity.Where(a => a.Code.StartsWith(input.Code))
                };
            }
            return base.GetListAsync(input, methodStringType, includeDetails, cancellationToken);
        }

        public override async Task<OrganizationUnit> CreateAsync(OrganizationUnitCreateInputDto input, bool autoSave = false, CancellationToken cancellationToken = default)
		{
			var organizationUnit = new OrganizationUnit(GuidGenerator.Create(), input.DisplayName, input.ParentId, input.TenantId);
			organizationUnit.ConcurrencyStamp = input.ConcurrencyStamp;
            input.RoleIds = await GetAllRoleIdAsync();//添加所有的角色到该组织
            if (input.RoleIds != null)
            {
                foreach (var item in input.RoleIds)
                {
                    organizationUnit.AddRole(item);
                }
            }
            if (input.ExtraProperties.Count > 0)
            {
                //organizationUnit.ExtraProperties.Clear();
                foreach (var item in input.ExtraProperties)
                {
                    organizationUnit.SetProperty(item.Key, item.Value);
                    //organizationUnit.ExtraProperties.Add(item.Key, item.Value);
                }
            }
            await organizationUnitManager.CreateAsync(organizationUnit);
			return organizationUnit;
		}

        public override async Task<OrganizationUnit> DeleteAsync(Guid id, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            await organizationUnitManager.DeleteAsync(id);//自动禁用下级
			return default;
        }

        public override async Task<OrganizationUnit[]> DeleteAsync(Guid[] keys, bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
            foreach (var item in keys)
            {
				await organizationUnitManager.DeleteAsync(item);//自动禁用下级
			}
			return default;
		}

        public override async Task<OrganizationUnit[]> DeleteAsync(OrganizationUnitDeleteInputDto deleteInputDto, string methodStringType = "Equals", bool autoSave = false, bool isHard = false, CancellationToken cancellationToken = default)
        {
			var query = await CreateFilteredQueryAsync(deleteInputDto, methodStringType);
            foreach (var item in query.ToArray())
            {
				await organizationUnitManager.DeleteAsync(item.Id);//自动禁用下级
			}
			return default;
		}

        public override async Task<OrganizationUnitDto> UpdateAsync(Guid id, OrganizationUnitUpdateInputDto input)
        {
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
                entity.ExtraProperties.Clear();
                foreach (var item in input.ExtraProperties)
                {
                    entity.ExtraProperties.Add(item.Key, item.Value);
                }
            }
            await CurrentUnitOfWork.SaveChangesAsync();
            await organizationUnitManager.MoveAsync(id, input.ParentId);
			return await MapToGetOutputDtoAsync(entity);
        }

		/// <summary>
		/// 自动恢复子级
		/// </summary>
		/// <param name="id"></param>
		/// <param name="isDeleted"></param>
		/// <returns></returns>
		public virtual async Task RecoverAsync(Guid id, bool isDeleted = false)
		{
			foreach (var item in await GetParentsAsync(id,!isDeleted))
			{
				item.IsDeleted = isDeleted;
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

        public virtual async Task<List<IdentityRole>> GetRolesAsync(Guid organizationUnitId)
        {
            var org = await GetEntityByIdAsync(organizationUnitId);
            return await organizationUnitsRepository.GetRolesAsync(org);
        }

        public virtual async Task<List<IdentityUser>> GetMembersAsync(Guid organizationUnitId)
        {
            var org = await GetEntityByIdAsync(organizationUnitId);
            return await organizationUnitsRepository.GetMembersAsync(org);
        }

        private async Task<Guid[]> GetAllRoleIdAsync()
        {
            return (await identityRoleRepository.GetQueryableAsync(false)).AsNoTracking().Select(a=>a.Id).ToArray();
        }

        public virtual async Task CreateByRoleAsync(Guid roleId)
        {
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
