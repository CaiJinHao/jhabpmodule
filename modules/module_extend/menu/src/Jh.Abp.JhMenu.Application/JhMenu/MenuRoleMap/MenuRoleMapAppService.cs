using Jh.Abp.Application;
using Jh.Abp.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Distributed;

namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapAppService
        : CrudApplicationService<MenuRoleMap, MenuRoleMapDto, MenuRoleMapDto, System.Guid, MenuRoleMapRetrieveInputDto, MenuRoleMapCreateInputDto, MenuRoleMapUpdateInputDto, MenuRoleMapDeleteInputDto>,
        IMenuRoleMapAppService
    {
        protected MenuRoleMapManager MenuRoleMapManager => LazyServiceProvider.LazyGetRequiredService<MenuRoleMapManager>();
        protected Jh.Abp.JhIdentity.IIdentityUserAppService IdentityUserRemoteService => LazyServiceProvider.LazyGetRequiredService<Jh.Abp.JhIdentity.IIdentityUserAppService>();
        protected IMenuRepository MenuRepository => LazyServiceProvider.LazyGetRequiredService<IMenuRepository>();
        protected readonly IMenuRoleMapRepository MenuRoleMapRepository;
        protected readonly IMenuRoleMapDapperRepository MenuRoleMapDapperRepository;
        public MenuRoleMapAppService(IMenuRoleMapRepository repository, IMenuRoleMapDapperRepository menurolemapDapperRepository) : base(repository)
        {
            MenuRoleMapRepository = repository;
            MenuRoleMapDapperRepository = menurolemapDapperRepository;
            CreatePolicyName = JhMenuPermissions.MenuRoleMaps.Create;
            GetListPolicyName = JhMenuPermissions.MenuRoleMaps.Default;
        }

        public async override Task<MenuRoleMapDto> CreateAsync(MenuRoleMapCreateInputDto input)
        {
            await CheckCreatePolicyAsync();
            await MenuRoleMapManager.CreateAsync(input.RoleIds, input.MenuIds, CurrentTenant.Id);
            return default;
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
            await CheckGetListPolicyAsync();
            var roles = await GetRolesAsync();
            var auth_menus_id = (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => roles.Contains(a.RoleId)).Select(a => a.MenuId).ToList();

            //按照前端要求字段返回
            var auth_menus = await (await MenuRepository.GetQueryableAsync()).AsNoTracking().Where(m => auth_menus_id.Contains(m.Id))
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
            var roles = await IdentityUserRemoteService.GetRolesAsync((Guid)CurrentUser.Id);
            return roles.Items.Select(a => a.Id);
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusTreesAsync(MenuRoleMapRetrieveInputDto input)
        {
            await CheckGetListPolicyAsync();
            var auth_menus_id =await (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => a.RoleId == input.RoleId).Select(a => a.MenuId).ToListAsync();

            var resutlMenus = await (await MenuRepository.GetQueryableAsync()).AsNoTracking().Select(a =>
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

        public virtual async Task<IEnumerable<CurrentUserNavMenusDto>> GeCurrentUserNavMenusAsync()
        {
            var roles = await GetRolesAsync();
            var auth_menus_id = (await crudRepository.GetQueryableAsync()).AsNoTracking().Where(a => roles.Contains(a.RoleId)).Select(a => a.MenuId).ToList();

            //按照前端要求字段返回
            var auth_menus = await (await MenuRepository.GetQueryableAsync()).AsNoTracking().Where(m => auth_menus_id.Contains(m.Id))
                .Select(a => new CurrentUserNavMenusDto() { Code = a.MenuCode, Name = a.MenuName, Path = a.MenuUrl, Icon = a.MenuIcon, Sort = a.MenuSort, ParentCode = a.MenuParentCode }).ToListAsync();

            //返回多个根节点
            return await GetMenusTreeAsync(auth_menus);
        }

        protected  async Task<List<CurrentUserNavMenusDto>> GetMenusTreeAsync(List<CurrentUserNavMenusDto> menus)
        {
            //组装树
            async Task<IEnumerable<CurrentUserNavMenusDto>> GetChildNodesAsync(string parentNodeId)
            {
                var childs = menus.Where(a => a.ParentCode == parentNodeId);
                foreach (var item in childs)
                {
                    var _data = await GetChildNodesAsync(item.Code);
                    item.Routes = _data.OrderBy(a => a.Sort).ToList();
                }
                return childs.OrderBy(a => a.Sort).ToList();
            }

            //找到根节点
            var roots = menus.Where(a => a.ParentCode == null || a.ParentCode == "").OrderBy(a => a.Sort).ToList();
            foreach (var item in roots)
            {
                var _data = await GetChildNodesAsync(item.Code);
                item.Routes = _data.OrderBy(a => a.Sort).ToList();
            }
            return roots;
        }
    }
}
