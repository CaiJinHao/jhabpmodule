using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public interface IJhIdentityDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
