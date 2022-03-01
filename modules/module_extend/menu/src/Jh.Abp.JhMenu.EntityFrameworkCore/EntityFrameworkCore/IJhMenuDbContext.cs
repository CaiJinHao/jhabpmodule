using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public interface IJhMenuDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
