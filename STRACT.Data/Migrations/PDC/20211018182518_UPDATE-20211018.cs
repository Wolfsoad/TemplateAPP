using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.PDC
{
    public partial class UPDATE20211018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionPlanRevisionId",
                principalSchema: "PDC",
                principalTable: "ActionPlanRevision",
                principalColumn: "ActionPlanRevisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_Department_DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                column: "DepartmentId",
                principalSchema: "PDC",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_Department_DepartmentId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_DepartmentId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionPlanRevisionId",
                principalSchema: "PDC",
                principalTable: "ActionPlanRevision",
                principalColumn: "ActionPlanRevisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
