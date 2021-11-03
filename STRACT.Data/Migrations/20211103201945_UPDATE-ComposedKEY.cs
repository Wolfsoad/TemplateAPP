using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATEComposedKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId");
        }
    }
}
