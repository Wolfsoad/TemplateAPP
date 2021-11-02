using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UpdateDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySkill_Skill_SkillsSkillId",
                schema: "PDC",
                table: "ActivitySkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_SkillGroups_SkillGroupId",
                schema: "PDC",
                table: "Skill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skill",
                schema: "PDC",
                table: "Skill");

            migrationBuilder.RenameTable(
                name: "Skill",
                schema: "PDC",
                newName: "Skills",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_Skill_SkillGroupId",
                schema: "PDC",
                table: "Skills",
                newName: "IX_Skills_SkillGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                schema: "PDC",
                table: "Skills",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySkill_Skills_SkillsSkillId",
                schema: "PDC",
                table: "ActivitySkill",
                column: "SkillsSkillId",
                principalSchema: "PDC",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_SkillGroups_SkillGroupId",
                schema: "PDC",
                table: "Skills",
                column: "SkillGroupId",
                principalSchema: "PDC",
                principalTable: "SkillGroups",
                principalColumn: "SkillGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivitySkill_Skills_SkillsSkillId",
                schema: "PDC",
                table: "ActivitySkill");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_SkillGroups_SkillGroupId",
                schema: "PDC",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                schema: "PDC",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                schema: "PDC",
                newName: "Skill",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SkillGroupId",
                schema: "PDC",
                table: "Skill",
                newName: "IX_Skill_SkillGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skill",
                schema: "PDC",
                table: "Skill",
                column: "SkillId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitySkill_Skill_SkillsSkillId",
                schema: "PDC",
                table: "ActivitySkill",
                column: "SkillsSkillId",
                principalSchema: "PDC",
                principalTable: "Skill",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_SkillGroups_SkillGroupId",
                schema: "PDC",
                table: "Skill",
                column: "SkillGroupId",
                principalSchema: "PDC",
                principalTable: "SkillGroups",
                principalColumn: "SkillGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
