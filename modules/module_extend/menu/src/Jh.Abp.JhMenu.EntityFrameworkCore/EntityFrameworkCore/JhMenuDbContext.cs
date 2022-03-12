using Jh.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public class JhMenuDbContext : JhAbpDbContext<JhMenuDbContext>, IJhMenuDbContext
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuRoleMap> MenuRoleMaps { get; set; }

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
