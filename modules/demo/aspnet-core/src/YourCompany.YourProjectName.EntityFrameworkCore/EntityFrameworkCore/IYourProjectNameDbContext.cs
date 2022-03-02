using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

[ConnectionStringName(YourProjectNameDbProperties.ConnectionStringName)]
public interface IYourProjectNameDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
