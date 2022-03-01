using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

public class JhIdentityHttpApiHostMigrationsDbContext : AbpDbContext<JhIdentityHttpApiHostMigrationsDbContext>
{
    public JhIdentityHttpApiHostMigrationsDbContext(DbContextOptions<JhIdentityHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureJhIdentity();
    }
}
