using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATEDBSETS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroup_Activities_ActivityId",
                schema: "PDC",
                table: "ActivityInGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroup_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityInGroup",
                schema: "PDC",
                table: "ActivityInGroup");

            migrationBuilder.RenameTable(
                name: "ActivityInGroup",
                schema: "PDC",
                newName: "ActivityInGroups",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityInGroup_ActivityId",
                schema: "PDC",
                table: "ActivityInGroups",
                newName: "IX_ActivityInGroups_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityInGroups",
                schema: "PDC",
                table: "ActivityInGroups",
                columns: new[] { "ActivityGroupId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInGroups_Activities_ActivityId",
                schema: "PDC",
                table: "ActivityInGroups",
                column: "ActivityId",
                principalSchema: "PDC",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInGroups_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroups",
                column: "ActivityGroupId",
                principalSchema: "PDC",
                principalTable: "ActivityGroups",
                principalColumn: "ActivityGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroups_Activities_ActivityId",
                schema: "PDC",
                table: "ActivityInGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroups_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityInGroups",
                schema: "PDC",
                table: "ActivityInGroups");

            migrationBuilder.RenameTable(
                name: "ActivityInGroups",
                schema: "PDC",
                newName: "ActivityInGroup",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ActivityInGroups_ActivityId",
                schema: "PDC",
                table: "ActivityInGroup",
                newName: "IX_ActivityInGroup_ActivityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityInGroup",
                schema: "PDC",
                table: "ActivityInGroup",
                columns: new[] { "ActivityGroupId", "ActivityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInGroup_Activities_ActivityId",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityId",
                principalSchema: "PDC",
                principalTable: "Activities",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInGroup_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityGroupId",
                principalSchema: "PDC",
                principalTable: "ActivityGroups",
                principalColumn: "ActivityGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
