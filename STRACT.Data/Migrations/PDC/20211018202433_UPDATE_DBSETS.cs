using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.PDC
{
    public partial class UPDATE_DBSETS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionGroup_ActionGroupId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionGroup",
                schema: "PDC",
                table: "ActionGroup");

            migrationBuilder.RenameTable(
                name: "ActionGroup",
                schema: "PDC",
                newName: "ActionGroups",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionGroups",
                schema: "PDC",
                table: "ActionGroups",
                column: "ActionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionGroups_ActionGroupId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionGroupId",
                principalSchema: "PDC",
                principalTable: "ActionGroups",
                principalColumn: "ActionGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionGroups_ActionGroupId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionGroups",
                schema: "PDC",
                table: "ActionGroups");

            migrationBuilder.RenameTable(
                name: "ActionGroups",
                schema: "PDC",
                newName: "ActionGroup",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionGroup",
                schema: "PDC",
                table: "ActionGroup",
                column: "ActionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionGroup_ActionGroupId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionGroupId",
                principalSchema: "PDC",
                principalTable: "ActionGroup",
                principalColumn: "ActionGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
