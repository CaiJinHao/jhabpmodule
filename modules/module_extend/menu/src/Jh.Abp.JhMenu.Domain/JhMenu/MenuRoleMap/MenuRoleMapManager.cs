
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Jh.Abp.JhMenu
{
    public class MenuRoleMapManager : DomainService
    {
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
            Logger.LogInformation($"菜单列表数量:{menuIds.Length}");
            if (menuIds.Any())
            {
                Logger.LogInformation($"开始创建:{menuIds.Length}");
                if (!(await MenuRoleMapRepository.GetQueryableAsync()).Any(a => a.RoleId == roleId))
                {
                    Logger.LogInformation($"开始为角色创建菜单:{roleId}，租户：{TenantId}");
                    await CreateAsync(roleId, menuIds, TenantId);
                }
                else
                {
                    Logger.LogInformation($"当前角色已存在菜单:{roleId}");
                }
            }
        }
    }
}
