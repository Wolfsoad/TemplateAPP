using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UpdateChronogramLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionItemId",
                schema: "PDC",
                table: "ChronogramLine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramLine_ActionItemId",
                schema: "PDC",
                table: "ChronogramLine",
                column: "ActionItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronogramLine_ActionItem_ActionItemId",
                schema: "PDC",
                table: "ChronogramLine",
                column: "ActionItemId",
                principalSchema: "PDC",
                principalTable: "ActionItem",
                principalColumn: "ActionItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronogramLine_ActionItem_ActionItemId",
                schema: "PDC",
                table: "ChronogramLine");

            migrationBuilder.DropIndex(
                name: "IX_ChronogramLine_ActionItemId",
                schema: "PDC",
                table: "ChronogramLine");

            migrationBuilder.DropColumn(
                name: "ActionItemId",
                schema: "PDC",
                table: "ChronogramLine");
        }
    }
}
