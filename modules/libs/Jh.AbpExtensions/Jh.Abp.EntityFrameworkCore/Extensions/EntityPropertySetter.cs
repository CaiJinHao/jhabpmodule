using Jh.Abp.Domain;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Timing;
using Volo.Abp.Users;

namespace Jh.Abp.EntityFrameworkCore
{
    public class EntityPropertySetter : IEntityPropertySetter, ITransientDependency
    {
        protected ICurrentUser CurrentUser { get; }
        protected ICurrentTenant CurrentTenant { get; }
        protected IClock Clock { get; }

        public EntityPropertySetter(
        ICurrentUser currentUser,
        ICurrentTenant currentTenant,
        IClock clock)
        {
            CurrentUser = currentUser;
            CurrentTenant = currentTenant;
            Clock = clock;
        }

        public void SetTenantProperties(object targetObject)
        {
            if (!CurrentTenant.Id.HasValue)
            {
                return;
            }

            if (targetObject is IMultiTenant multiTenantEntity)
            {
                if (multiTenantEntity.TenantId.HasValue && multiTenantEntity.TenantId.Value != default)
                {
                    return;
                }

                ObjectHelper.TrySetProperty(multiTenantEntity, x => x.TenantId, () => CurrentTenant.Id.Value);
            }
        }
    }
}
