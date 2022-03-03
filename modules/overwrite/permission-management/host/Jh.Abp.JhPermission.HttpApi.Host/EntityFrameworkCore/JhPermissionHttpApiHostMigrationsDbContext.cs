using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhPermission.EntityFrameworkCore;

public class JhPermissionHttpApiHostMigrationsDbContext : AbpDbContext<JhPermissionHttpApiHostMigrationsDbContext>
{
    public JhPermissionHttpApiHostMigrationsDbContext(DbContextOptions<JhPermissionHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureJhPermission();
    }
}
