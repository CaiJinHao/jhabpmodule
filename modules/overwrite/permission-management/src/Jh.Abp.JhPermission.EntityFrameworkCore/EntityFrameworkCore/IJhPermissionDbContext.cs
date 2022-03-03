using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhPermission.EntityFrameworkCore;

[ConnectionStringName(JhPermissionDbProperties.ConnectionStringName)]
public interface IJhPermissionDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
