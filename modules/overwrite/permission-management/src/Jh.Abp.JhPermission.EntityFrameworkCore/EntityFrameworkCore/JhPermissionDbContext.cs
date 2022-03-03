using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhPermission.EntityFrameworkCore;

[ConnectionStringName(JhPermissionDbProperties.ConnectionStringName)]
public class JhPermissionDbContext : AbpDbContext<JhPermissionDbContext>, IJhPermissionDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public JhPermissionDbContext(DbContextOptions<JhPermissionDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureJhPermission();
    }
}
