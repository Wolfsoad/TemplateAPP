using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update20220123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertInProject_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "AlertInProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ChronogramRevision_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoards_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItem_UserInTeam_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMember_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ToDoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInProject_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "TopicInProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectItem",
                schema: "PDC",
                table: "ProjectItem");

            migrationBuilder.RenameTable(
                name: "ProjectItem",
                schema: "PDC",
                newName: "ProjectItems",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItem_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItems",
                newName: "IX_ProjectItems_CoordinatorUserInTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectItems",
                schema: "PDC",
                table: "ProjectItems",
                column: "ProjectItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertInProject_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "AlertInProject",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChronogramRevision_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoards_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItems_UserInTeam_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItems",
                column: "CoordinatorUserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMember_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ProjectMember",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ToDoTask",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInProject_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "TopicInProject",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItems",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertInProject_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "AlertInProject");

            migrationBuilder.DropForeignKey(
                name: "FK_ChronogramRevision_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ChronogramRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoards_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectItems_UserInTeam_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMember_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "ToDoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInProject_ProjectItems_ProjectItemId",
                schema: "PDC",
                table: "TopicInProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectItems",
                schema: "PDC",
                table: "ProjectItems");

            migrationBuilder.RenameTable(
                name: "ProjectItems",
                schema: "PDC",
                newName: "ProjectItem",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectItems_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItem",
                newName: "IX_ProjectItem_CoordinatorUserInTeamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectItem",
                schema: "PDC",
                table: "ProjectItem",
                column: "ProjectItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertInProject_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "AlertInProject",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChronogramRevision_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoards_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectItem_UserInTeam_CoordinatorUserInTeamId",
                schema: "PDC",
                table: "ProjectItem",
                column: "CoordinatorUserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMember_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ProjectMember",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoTask_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ToDoTask",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInProject_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "TopicInProject",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
