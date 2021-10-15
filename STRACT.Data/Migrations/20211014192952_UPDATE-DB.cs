using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATEDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronogramRevision_UserInTeam_UserId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.DropIndex(
                name: "IX_ChronogramRevision_UserId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.AddColumn<int>(
                name: "ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserHoliday",
                schema: "PDC",
                columns: table => new
                {
                    UserHolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataOfHoliday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserInTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHoliday", x => x.UserHolidayId);
                    table.ForeignKey(
                        name: "FK_UserHoliday_UserInTeam_UserInTeamId",
                        column: x => x.UserInTeamId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramRevision_ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHoliday_UserInTeamId",
                schema: "PDC",
                table: "UserHoliday",
                column: "UserInTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronogramRevision_UserInTeam_ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "ResponsibleUserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronogramRevision_UserInTeam_ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.DropTable(
                name: "UserHoliday",
                schema: "PDC");

            migrationBuilder.DropIndex(
                name: "IX_ChronogramRevision_ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.DropColumn(
                name: "ResponsibleUserId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramRevision_UserId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronogramRevision_UserInTeam_UserId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
