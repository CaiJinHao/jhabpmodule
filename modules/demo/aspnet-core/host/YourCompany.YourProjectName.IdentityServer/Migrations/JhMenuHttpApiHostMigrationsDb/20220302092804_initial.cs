using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourCompany.YourProjectName.Migrations.JhMenuHttpApiHostMigrationsDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu_Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MenuCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "菜单编号"),
                    MenuName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "菜单名称"),
                    MenuIcon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "菜单图标"),
                    MenuSort = table.Column<int>(type: "int", nullable: false, comment: "菜单排序"),
                    MenuParentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, comment: "菜单上级菜单编号"),
                    MenuUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "菜单导航路径"),
                    MenuDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true, comment: "菜单描述"),
                    MenuPlatform = table.Column<int>(type: "int", nullable: false, comment: "菜单所属平台"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Menu", x => x.Id);
                },
                comment: "菜单");

            migrationBuilder.CreateTable(
                name: "Menu_MenuRoleMap",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false, comment: "菜单Id"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false, comment: "用户角色"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                comment: "菜单角色中间表");

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
