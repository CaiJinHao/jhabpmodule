using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Uow;

namespace Jh.Abp.JhMenu
{
    public class RoleMenuInitEventHandler : IDistributedEventHandler<RoleMenuInitEto>, ITransientDependency
    {
        protected MenuRoleMapManager MenuRoleMapManager;
        public RoleMenuInitEventHandler(MenuRoleMapManager menuRoleMapManager)
        {
            MenuRoleMapManager = menuRoleMapManager;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(RoleMenuInitEto eventData)
        {
            await MenuRoleMapManager.InitMenuByRole(eventData.RoleIds);
        }
    }
}
