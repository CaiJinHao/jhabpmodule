
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapManager : DomainService
    {
        //TODO:租户信息待测试
        public ICurrentTenant CurrentTenant { get; set; }

        protected IMenuRoleMapRepository MenuRoleMapRepository { get; }
        protected IMenuRepository MenuRepository { get; }
        public MenuRoleMapManager(IMenuRoleMapRepository menuRoleMapRepository, IMenuRepository menuRepository)
        {
            MenuRoleMapRepository = menuRoleMapRepository;
            MenuRepository = menuRepository;
        }

        protected virtual IEnumerable<MenuRoleMap> CreateList(Guid roleid, Guid[] MenuIds, Guid? TenantId)
        {
            Volo.Abp.Check.NotNull(roleid, nameof(roleid));
            foreach (var menuid in MenuIds)
            {
                yield return new MenuRoleMap(menuid, roleid, TenantId);
            }
        }

        protected virtual async Task CreateAsync(Guid roleId, Guid[] MenuIds, Guid? TenantId)
        {
            await MenuRoleMapRepository.DeleteListAsync(a => roleId == a.RoleId);
            var entitys = CreateList(roleId, MenuIds, TenantId);
            if (entitys.Any())
            {
                await MenuRoleMapRepository.CreateAsync(entitys.ToArray());
            }
        }

        protected virtual async Task CreateAsync(Guid roleId, Guid menuId)
        {
            var query = (await MenuRoleMapRepository.GetQueryableAsync()).Where(a => a.RoleId == roleId && a.MenuId == menuId);
            if (!query.Any())
            {
                await MenuRoleMapRepository.CreateAsync(new MenuRoleMap(menuId, roleId));
            }
        }

        public virtual async Task CreateAsync(Guid[] RoleIds, Guid[] MenuIds, Guid? TenantId)
        {
            foreach (var item in RoleIds)
            {
                await CreateAsync(item,MenuIds, TenantId);
            }
        }

        public virtual async Task InitMenuByRoleAsync(Guid roleId, Guid[] menuIds, Guid? TenantId)
        {
            Volo.Abp.Check.NotNull(roleId, nameof(roleId));
            if (menuIds.Any())
            {
                if (!(await MenuRoleMapRepository.GetQueryableAsync()).Any(a => a.RoleId == roleId))
                {
                    await CreateAsync(roleId, menuIds, TenantId);
                }
            }
        }

        /// <summary>
        /// 每次启动都会初始化
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuIds"></param>
        /// <returns></returns>
        public virtual async Task InitMenuByRoleAsync(Guid roleId, Guid[] menuIds)
        {
            Volo.Abp.Check.NotNull(roleId, nameof(roleId));
            if (menuIds.Any())
            {
                foreach (var item in menuIds)
                {
                    await CreateAsync(roleId, item);
                }
            }
        }
    }
}
