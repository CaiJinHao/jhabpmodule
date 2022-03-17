using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public class JhIdentityDbContext : AbpDbContext<JhIdentityDbContext>, IJhIdentityDbContext
{

    public DbSet<JhOrganizationUnit> OrganizationUnits { get; set; }


    public JhIdentityDbContext(DbContextOptions<JhIdentityDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        //一个数据上下文只能配置一个实体对应一个表

        //扩展只能用来查询
        builder.Entity<JhOrganizationUnit>(b => {

            b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "OrganizationUnits", AbpIdentityDbProperties.DbSchema);
            b.ConfigureByConvention();

            b.ApplyObjectExtensionMappings();
        });


        builder.ConfigureJhIdentity();

    }
}
