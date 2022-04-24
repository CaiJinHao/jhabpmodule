using Jh.Abp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.EntityFrameworkCore
{
    public abstract class JhAbpDbContext<TDbContext> : AbpDbContext<TDbContext>
        where TDbContext : DbContext
    {
        protected IEntityPropertySetter EntityPropertySetter => LazyServiceProvider.LazyGetRequiredService<IEntityPropertySetter>();
        protected JhAbpDbContext(DbContextOptions<TDbContext> options) : base(options)
        {
        }

        protected override void ApplyAbpConceptsForAddedEntity(EntityEntry entry)
        {
            base.ApplyAbpConceptsForAddedEntity(entry);
            SetCreationTenantProperties(entry);
        }

        protected virtual void SetCreationTenantProperties(EntityEntry entry)
        {
            EntityPropertySetter?.SetTenantProperties(entry.Entity);
        }
    }
}
