using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using Volo.Abp;
using JetBrains.Annotations;
using Volo.Abp.Identity;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity.EntityFrameworkCore;
using Jh.Abp.JhIdentity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public static class JhIdentityDbContextModelBuilderExtensions
    {
        public static void ConfigureJhIdentity([NotNull] this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            builder.Entity<OrganizationUnitExtension>(b =>
            {
                b.HasComment("组织扩展表");
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "OrganizationUnitExtensions", AbpIdentityDbProperties.DbSchema);
                b.ConfigureByConvention();
                b.Property(a => a.Id).ValueGeneratedNever();

                b.Property(x => x.LeaderId).HasComment("用户ID");
                b.Property(x => x.LeaderType).HasComment("领导类型");

                b.HasIndex(x => x.LeaderId);

                b.ApplyObjectExtensionMappings();
            });

            builder.TryConfigureObjectExtensions<JhIdentityDbContext>();
        }
    }
}
