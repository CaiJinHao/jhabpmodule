using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Jh.Abp.JhMenu.EntityFrameworkCore;

public static class JhMenuDbContextModelCreatingExtensions
{
    public static void ConfigureJhMenu(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(JhMenuDbProperties.DbTablePrefix + "Questions", JhMenuDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */

        builder.Entity<Menu>(b => {
            b.HasComment("菜单");
            b.ToTable(JhMenuDbProperties.DbTablePrefix + "Menu", JhMenuDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).ValueGeneratedOnAdd();

            b.Property(p => p.MenuCode).HasMaxLength(20).HasComment("菜单编号");
            b.Property(p => p.MenuName).HasMaxLength(200).HasComment("菜单名称");
            b.Property(p => p.MenuIcon).HasMaxLength(100).HasComment("菜单图标");
            b.Property(p => p.MenuSort).HasComment("菜单排序");
            b.Property(p => p.MenuParentCode).HasMaxLength(20).HasComment("菜单上级菜单编号");
            b.Property(p => p.MenuUrl).HasMaxLength(500).HasComment("菜单导航路径");
            b.Property(p => p.MenuDescription).HasMaxLength(500).HasComment("菜单描述");
            b.Property(p => p.MenuPlatform).HasComment("菜单所属平台");

            b.HasIndex(c => new { c.MenuCode, c.TenantId }).IsUnique();
            b.HasIndex(c => c.MenuParentCode);

            b.ApplyObjectExtensionMappings();
        });

        builder.Entity<MenuRoleMap>(b => {
            b.HasComment("角色菜单");
            b.ToTable(JhMenuDbProperties.DbTablePrefix + "MenuRoleMap", JhMenuDbProperties.DbSchema);
            b.ConfigureByConvention();
            b.Property(p => p.Id).ValueGeneratedOnAdd();

            b.Property(p => p.MenuId).HasMaxLength(36).HasComment("菜单Id");
            b.Property(p => p.RoleId).HasMaxLength(36).HasComment("用户角色");

            b.HasOne(mrm => mrm.Menu).WithMany(menu => menu.MenuRoleMap).HasForeignKey(menu => menu.MenuId);//b.HasIndex(p => p.MenuId);
            b.HasIndex(c => c.RoleId);
            //sqlserver
            //b.HasIndex(c => c.RoleId).IncludeProperties(p => p.MenuId);//mysql不能使用包含列
        });
    }
}
