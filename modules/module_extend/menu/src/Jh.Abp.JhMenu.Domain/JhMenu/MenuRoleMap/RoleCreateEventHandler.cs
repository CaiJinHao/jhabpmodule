using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;

namespace Jh.Abp.JhMenu
{
    public class RoleCreateEventHandler :
    IDistributedEventHandler<EntityCreatedEto<IdentityRoleEto>>,
    ITransientDependency
    {
        public Task HandleEventAsync(EntityCreatedEto<IdentityRoleEto> eventData)
        {
            throw new DataMisalignedException($"RoleCreateEventHandler:{eventData.Entity.Id},{eventData.Entity.Name}");
        }
    }
}
