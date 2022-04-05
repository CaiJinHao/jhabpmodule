using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.Uow;
using System.Linq;

namespace Jh.Abp.JhMenu
{
    /// <summary>
    /// 只为admin用户添加菜单权限
    /// </summary>
    public class RoleCreateEventHandler :IDistributedEventHandler<EntityCreatedEto<IdentityRoleEto>>,ITransientDependency
    {
        public ILogger<RoleCreateEventHandler> Logger { get; set; }
        protected MenuManager MenuManager;
        protected MenuRoleMapManager MenuRoleMapManager;
        public RoleCreateEventHandler(MenuManager menuManager, MenuRoleMapManager menuRoleMapManager)
        {
            MenuRoleMapManager = menuRoleMapManager;
            MenuManager = menuManager;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityCreatedEto<IdentityRoleEto> eventData)
        {
            Logger.LogInformation($"RoleCreateEventHandler:{eventData.Entity.Name},{eventData.Entity.Name.Equals("admin")},{eventData.Entity.TenantId}");
            if (eventData.Entity.Name.Equals("admin"))
            {
                var menus = await MenuManager.InitMenuAsync(eventData.Entity.TenantId);
                await MenuRoleMapManager.InitMenuByRoleAsync(eventData.Entity.Id, menus.Select(a => a.Id).ToArray(), eventData.Entity.TenantId);
            }
        }
    }
}
