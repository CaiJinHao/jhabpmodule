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
        public async Task HandleEventAsync(EntityCreatedEto<IdentityRoleEto> eventData)
        {
            Logger.LogInformation($"RoleCreateEventHandler:{eventData.Entity.Name},{eventData.Entity.Name.Equals("admin")}");
            if (eventData.Entity.Name.Equals("admin"))
            {
                await MenuManager.InitMenuAsync(eventData.Entity.TenantId);
                await MenuRoleMapManager.InitMenuByRole(eventData.Entity.Id,eventData.Entity.TenantId);
            }
        }
    }
}
