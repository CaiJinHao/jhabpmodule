using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

public class JhMenuHttpApiHostMigrationsDbContext : AbpDbContext<JhMenuHttpApiHostMigrationsDbContext>
{
    public JhMenuHttpApiHostMigrationsDbContext(DbContextOptions<JhMenuHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureJhMenu();
    }
}
