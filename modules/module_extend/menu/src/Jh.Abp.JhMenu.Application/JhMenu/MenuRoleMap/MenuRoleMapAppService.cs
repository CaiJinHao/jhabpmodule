using Jh.Abp.Common;
using Jh.Abp.Extensions;
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
            await CheckCreatePolicyAsync().ConfigureAwait(false);
            await menuRoleMapManager.CreateAsync(inputDto.RoleIds, inputDto.MenuIds);
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
            await CheckGetListPolicyAsync().ConfigureAwait(false);
            var roles = GetRolesAsync();
            var auth_menus_id = (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => roles.Contains(a.RoleId)).Select(a => a.MenuId).ToList();

            //按照前端要求字段返回
            var auth_menus = await (await menuRepository.GetQueryableAsync()).AsNoTracking().Where(m => auth_menus_id.Contains(m.Id))
                .Select(a => new TreeDto() { value = a.MenuCode, id = a.MenuCode, icon = a.MenuIcon, parent_id = a.MenuParentCode, sort = a.MenuSort.ToString(), title = a.MenuName, url = a.MenuUrl, obj = a }).ToListAsync();

            //返回多个根节点
            return await UtilTree.GetMenusTreeAsync(auth_menus);
        }

        protected virtual IEnumerable<Guid> GetRolesAsync()
        {
            return CurrentUser.FindClaims(Common.Extensions.JhJwtClaimTypes.RoleId).Select(a => new Guid(a.Value)).ToList();
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync().ConfigureAwait(false);
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
