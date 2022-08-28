using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public class JhIdentityDbContext : AbpDbContext<JhIdentityDbContext>, IJhIdentityDbContext
{
    public DbSet<OrganizationUnitExtension> OrganizationUnitExtensions { get; set; }

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
