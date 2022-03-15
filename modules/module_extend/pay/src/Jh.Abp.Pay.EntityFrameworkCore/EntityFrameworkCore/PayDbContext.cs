using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.Pay.EntityFrameworkCore;

[ConnectionStringName(PayDbProperties.ConnectionStringName)]
public class PayDbContext : AbpDbContext<PayDbContext>, IPayDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public PayDbContext(DbContextOptions<PayDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePay();
    }
}
