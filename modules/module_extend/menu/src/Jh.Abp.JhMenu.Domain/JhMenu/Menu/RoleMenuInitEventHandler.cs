using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace Jh.Abp.JhMenu
{
    public class RoleMenuInitEventHandler : IDistributedEventHandler<RoleMenuInitEto>, ITransientDependency
    {
        protected MenuRoleMapManager MenuRoleMapManager;
        public RoleMenuInitEventHandler(MenuRoleMapManager menuRoleMapManager)
        {
            MenuRoleMapManager = menuRoleMapManager;
        }

        public virtual async Task HandleEventAsync(RoleMenuInitEto eventData)
        {
            await MenuRoleMapManager.InitMenuByRole(eventData.RoleId);
        }
    }
}
