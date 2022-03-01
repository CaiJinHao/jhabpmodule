using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public class JhMenuDbContext : AbpDbContext<JhMenuDbContext>, IJhMenuDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public JhMenuDbContext(DbContextOptions<JhMenuDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureJhMenu();
    }
}
