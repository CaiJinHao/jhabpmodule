using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Pay.EntityFrameworkCore;

[ConnectionStringName(PayDbProperties.ConnectionStringName)]
public interface IPayDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
