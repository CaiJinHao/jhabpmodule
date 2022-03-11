using Jh.Abp.Application;
using Jh.Abp.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapAppService
        : CrudApplicationService<MenuRoleMap, MenuRoleMapDto, MenuRoleMapDto, System.Guid, MenuRoleMapRetrieveInputDto, MenuRoleMapCreateInputDto, MenuRoleMapUpdateInputDto, MenuRoleMapDeleteInputDto>,
        IMenuRoleMapAppService
    {
        protected Jh.Abp.JhIdentity.IIdentityUserRepository identityUserRepository => LazyServiceProvider.LazyGetRequiredService<Jh.Abp.JhIdentity.IIdentityUserRepository>();
        protected MenuRoleMapManager menuRoleMapManager =>LazyServiceProvider.LazyGetRequiredService<MenuRoleMapManager>();
        protected IMenuRepository menuRepository => LazyServiceProvider.LazyGetRequiredService<IMenuRepository>();
        protected readonly IMenuRoleMapRepository MenuRoleMapRepository;
        protected readonly IMenuRoleMapDapperRepository MenuRoleMapDapperRepository;
        public MenuRoleMapAppService(IMenuRoleMapRepository repository, IMenuRoleMapDapperRepository menurolemapDapperRepository) : base(repository)
        {
            MenuRoleMapRepository = repository;
            MenuRoleMapDapperRepository = menurolemapDapperRepository;
            CreatePolicyName = JhMenuPermissions.MenuRoleMaps.Create;
            UpdatePolicyName = JhMenuPermissions.MenuRoleMaps.Update;
            DeletePolicyName = JhMenuPermissions.MenuRoleMaps.Delete;
            GetPolicyName = JhMenuPermissions.MenuRoleMaps.Detail;
            GetListPolicyName = JhMenuPermissions.MenuRoleMaps.Default;
            BatchDeletePolicyName = JhMenuPermissions.MenuRoleMaps.BatchDelete;
        }

        public virtual async Task CreateByRoleAsync(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            await CheckCreatePolicyAsync();
            await menuRoleMapManager.CreateAsync(inputDto.RoleIds, inputDto.MenuIds);
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
            await CheckGetListPolicyAsync();
            var roles = await GetRolesAsync();
            var auth_menus_id = (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => roles.Contains(a.RoleId)).Select(a => a.MenuId).ToList();

            //按照前端要求字段返回
            var auth_menus = await (await menuRepository.GetQueryableAsync()).AsNoTracking().Where(m => auth_menus_id.Contains(m.Id))
                .Select(a => new TreeDto() { value = a.MenuCode, id = a.MenuCode, icon = a.MenuIcon, parent_id = a.MenuParentCode, sort = a.MenuSort.ToString(), title = a.MenuName, url = a.MenuUrl, obj = a }).ToListAsync();

            //返回多个根节点
            return await UtilTree.GetMenusTreeAsync(auth_menus);
        }

        protected virtual async Task<IEnumerable<Guid>> GetRolesAsync()
        {
            if (CurrentUser.Id == null)
            {
                return default;
            }
            var roles = await identityUserRepository.GetRolesAsync((Guid)CurrentUser.Id);
            return roles.Select(a => a.Id);
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            var auth_menus_id =await (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => a.RoleId == input.RoleId).Select(a => a.MenuId).ToListAsync();

            var resutlMenus = await (await menuRepository.GetQueryableAsync()).AsNoTracking().Select(a =>
                new TreeDto()
                {
                    id = a.MenuCode,
                    icon = a.MenuIcon,
                    parent_id = a.MenuParentCode,
                    sort = a.MenuSort.ToString(),
                    title = a.MenuName,
                    url = a.MenuUrl,
                    value = a.Id.ToString(),
                    @checked = auth_menus_id.Contains(a.Id),
                    disabled = false,
                    obj = a
                }
            ).ToListAsync();

            //返回多个根节点
            return await UtilTree.GetMenusTreeAsync(resutlMenus);
        }

    }
}
