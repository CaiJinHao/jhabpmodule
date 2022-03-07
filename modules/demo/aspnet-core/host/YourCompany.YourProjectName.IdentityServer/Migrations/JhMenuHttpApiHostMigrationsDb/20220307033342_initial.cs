using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourCompany.YourProjectName.Migrations.JhMenuHttpApiHostMigrationsDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu_Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MenuCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false, comment: "菜单编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, comment: "菜单名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuIcon = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "菜单图标")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuSort = table.Column<int>(type: "int", nullable: false, comment: "菜单排序"),
                    MenuParentCode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, comment: "菜单上级菜单编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, comment: "菜单导航路径")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuDescription = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true, comment: "菜单描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MenuPlatform = table.Column<int>(type: "int", nullable: false, comment: "菜单所属平台"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Menu", x => x.Id);
                },
                comment: "菜单")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu_MenuRoleMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    MenuId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, comment: "菜单Id", collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, comment: "用户角色", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_MenuRoleMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_MenuRoleMap_Menu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu_Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色菜单")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Menu_MenuCode",
                table: "Menu_Menu",
                column: "MenuCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Menu_MenuParentCode",
                table: "Menu_Menu",
                column: "MenuParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuRoleMap_MenuId",
                table: "Menu_MenuRoleMap",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuRoleMap_RoleId",
                table: "Menu_MenuRoleMap",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu_MenuRoleMap");

            migrationBuilder.DropTable(
                name: "Menu_Menu");
        }
    }
}
