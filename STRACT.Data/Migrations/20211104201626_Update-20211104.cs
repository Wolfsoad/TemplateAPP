using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update20211104 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHoliday_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "UserHoliday");

            migrationBuilder.DropIndex(
                name: "IX_Activities_FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHoliday",
                schema: "PDC",
                table: "UserHoliday");

            migrationBuilder.DropColumn(
                name: "FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.RenameTable(
                name: "UserHoliday",
                schema: "PDC",
                newName: "UserHolidays",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_UserHoliday_UserInTeamId",
                schema: "PDC",
                table: "UserHolidays",
                newName: "IX_UserHolidays_UserInTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHolidays",
                schema: "PDC",
                table: "UserHolidays",
                column: "UserHolidayId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserHolidays_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "UserHolidays",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHolidays_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "UserHolidays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHolidays",
                schema: "PDC",
                table: "UserHolidays");

            migrationBuilder.RenameTable(
                name: "UserHolidays",
                schema: "PDC",
                newName: "UserHoliday",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_UserHolidays_UserInTeamId",
                schema: "PDC",
                table: "UserHoliday",
                newName: "IX_UserHoliday_UserInTeamId");

            migrationBuilder.AddColumn<int>(
                name: "FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHoliday",
                schema: "PDC",
                table: "UserHoliday",
                column: "UserHolidayId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "OrganizationalRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "FunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FuntionalRoles",
                principalColumn: "FunctionalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHoliday_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "UserHoliday",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
