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
    public class MenuCreateEventHandler : IDistributedEventHandler<EntityCreatedEto<MenuEto>>, ITransientDependency
    {
        public IMenuDataSeeder  MenuDataSeeder { get; set; }
        public MenuRoleMapManager MenuRoleMapManager { get; set; }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityCreatedEto<MenuEto> eventData)
        {
            await MenuDataSeeder.MenuCreateEventSeedAsync(eventData.Entity.Id);
        }
    }
}
