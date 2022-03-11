﻿// <auto-generated />
using System;
using Jh.Abp.JhMenu.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volo.Abp.EntityFrameworkCore;

#nullable disable

namespace Jh.Abp.JhIdentity.Migrations.JhMenuHttpApiHostMigrationsDb
{
    [DbContext(typeof(JhMenuHttpApiHostMigrationsDbContext))]
    partial class JhMenuHttpApiHostMigrationsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("_Abp_DatabaseProvider", EfCoreDatabaseProvider.MySql)
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Jh.Abp.JhMenu.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("ConcurrencyStamp");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid?>("DeleterId")
                        .HasColumnType("char(36)")
                        .HasColumnName("DeleterId");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("DeletionTime");

                    b.Property<string>("ExtraProperties")
                        .HasColumnType("longtext")
                        .HasColumnName("ExtraProperties");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("LastModificationTime");

                    b.Property<Guid?>("LastModifierId")
                        .HasColumnType("char(36)")
                        .HasColumnName("LastModifierId");

                    b.Property<string>("MenuCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("菜单编号");

                    b.Property<string>("MenuDescription")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasComment("菜单描述");

                    b.Property<string>("MenuIcon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasComment("菜单图标");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasComment("菜单名称");

                    b.Property<string>("MenuParentCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasComment("菜单上级菜单编号");

                    b.Property<int>("MenuPlatform")
                        .HasColumnType("int")
                        .HasComment("菜单所属平台");

                    b.Property<int>("MenuSort")
                        .HasColumnType("int")
                        .HasComment("菜单排序");

                    b.Property<string>("MenuUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasComment("菜单导航路径");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("MenuParentCode");

                    b.HasIndex("MenuCode", "TenantId")
                        .IsUnique();

                    b.ToTable("Menu_Menu", (string)null);

                    b.HasComment("菜单");
                });

            modelBuilder.Entity("Jh.Abp.JhMenu.MenuRoleMap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("CreationTime");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("char(36)")
                        .HasColumnName("CreatorId");

                    b.Property<Guid>("MenuId")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasComment("菜单Id");

                    b.Property<Guid>("RoleId")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)")
                        .HasComment("用户角色");

                    b.Property<Guid?>("TenantId")
                        .HasColumnType("char(36)")
                        .HasColumnName("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("Menu_MenuRoleMap", (string)null);

                    b.HasComment("角色菜单");
                });

            modelBuilder.Entity("Jh.Abp.JhMenu.MenuRoleMap", b =>
                {
                    b.HasOne("Jh.Abp.JhMenu.Menu", "Menu")
                        .WithMany("MenuRoleMap")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Jh.Abp.JhMenu.Menu", b =>
                {
                    b.Navigation("MenuRoleMap");
                });
#pragma warning restore 612, 618
        }
    }
}
