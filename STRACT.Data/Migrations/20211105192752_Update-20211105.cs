using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update20211105 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserSkillsEvaluations",
                schema: "PDC",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    SkillScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillsEvaluations", x => new { x.UserId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserSkillsEvaluations_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "PDC",
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSkillsEvaluations_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserInTeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillsEvaluations_SkillId",
                schema: "PDC",
                table: "UserSkillsEvaluations",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkillsEvaluations",
                schema: "PDC");
        }
    }
}
