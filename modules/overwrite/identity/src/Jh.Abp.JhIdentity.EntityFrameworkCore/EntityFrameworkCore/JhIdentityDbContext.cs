using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public class JhIdentityDbContext : AbpDbContext<JhIdentityDbContext>, IJhIdentityDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public JhIdentityDbContext(DbContextOptions<JhIdentityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureJhIdentity();
    }
}
