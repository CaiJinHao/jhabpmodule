using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Pay.EntityFrameworkCore;

public class PayHttpApiHostMigrationsDbContext : AbpDbContext<PayHttpApiHostMigrationsDbContext>
{
    public PayHttpApiHostMigrationsDbContext(DbContextOptions<PayHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigurePay();
    }
}
