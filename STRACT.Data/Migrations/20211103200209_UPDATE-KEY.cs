using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATEKEY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInTeam_ApplicationUser_ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.DropIndex(
                name: "IX_UserInTeam_ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInTeam_ApplicationUser_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserInTeam_ApplicationUser_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.DropIndex(
                name: "IX_UserInTeam_ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                schema: "PDC",
                table: "UserInTeam",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserInTeam_ApplicationUser_ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId1",
                principalSchema: "Identity",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
