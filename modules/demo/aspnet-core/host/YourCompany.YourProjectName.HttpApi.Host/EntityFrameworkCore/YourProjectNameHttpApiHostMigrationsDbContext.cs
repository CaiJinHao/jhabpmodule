using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace YourCompany.YourProjectName.EntityFrameworkCore;

public class YourProjectNameHttpApiHostMigrationsDbContext : AbpDbContext<YourProjectNameHttpApiHostMigrationsDbContext>
{
    public YourProjectNameHttpApiHostMigrationsDbContext(DbContextOptions<YourProjectNameHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureYourProjectName();
    }
}
