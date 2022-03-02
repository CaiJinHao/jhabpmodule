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
        public IMenuRepository menuRepository => LazyServiceProvider.LazyGetRequiredService<IMenuRepository>();
        private readonly IMenuRoleMapRepository MenuRoleMapRepository;
        private readonly IMenuRoleMapDapperRepository MenuRoleMapDapperRepository;
        public MenuRoleMapAppService(IMenuRoleMapRepository repository, IMenuRoleMapDapperRepository menurolemapDapperRepository) : base(repository)
        {
            MenuRoleMapRepository = repository;
            MenuRoleMapDapperRepository = menurolemapDapperRepository;
        }

        public override Task<MenuRoleMap> CreateAsync(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override Task<MenuRoleMap[]> CreateAsync(MenuRoleMapCreateInputDto[] inputDtos, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<MenuRoleMap[]> CreateV2Async(MenuRoleMapCreateInputDto inputDto, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            return await crudRepository.CreateAsync(GetCreateEnumerableAsync(inputDto).ToArray());
        }

        protected virtual IEnumerable<MenuRoleMap> GetCreateEnumerableAsync(MenuRoleMapCreateInputDto inputDtos, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            foreach (var roleid in inputDtos.RoleIds)
            {
                //删除所有角色的权限
                DeleteAsync(new MenuRoleMapDeleteInputDto() { RoleId = roleid }).Wait();
                foreach (var menuid in inputDtos.MenuIds)
                {
                    yield return new MenuRoleMap(menuid, roleid);
                }
            }
        }

        public virtual async Task<IEnumerable<TreeDto>> GetMenusNavTreesAsync()
        {
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
