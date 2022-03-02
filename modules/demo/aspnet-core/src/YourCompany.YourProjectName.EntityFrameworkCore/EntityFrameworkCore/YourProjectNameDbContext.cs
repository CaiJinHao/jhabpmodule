using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

[ConnectionStringName(YourProjectNameDbProperties.ConnectionStringName)]
public class YourProjectNameDbContext : AbpDbContext<YourProjectNameDbContext>, IYourProjectNameDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public YourProjectNameDbContext(DbContextOptions<YourProjectNameDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureYourProjectName();
    }
}
