using Microsoft.EntityFrameworkCore.Migrations;

namespace Hff.JwtBackend.DataAccess.Migrations
{
    public partial class Fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId_AppUserId",
                table: "AppUserRoles",
                columns: new[] { "AppRoleId", "AppUserId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppUserRoles_AppRoleId_AppUserId",
                table: "AppUserRoles");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRoles_AppRoleId",
                table: "AppUserRoles",
                column: "AppRoleId");
        }
    }
}
