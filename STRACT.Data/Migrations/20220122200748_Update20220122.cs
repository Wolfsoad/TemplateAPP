using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update20220122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoard_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoard");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprint_KanbanBoard_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprint");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanban_KanbanBoard_KanbanBoardId",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanban_LocationInKanbans_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanban_Sprint_SprintId",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanban_Sprint_SprintId1",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanban_TaskItem_TaskItemId",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Audits_AuditId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Departments_DepartmentId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Priority_PriorityId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_TaskTypes_TaskTypeId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItem",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskInKanban",
                schema: "PDC",
                table: "TaskInKanban");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprint",
                schema: "PDC",
                table: "Sprint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanBoard",
                schema: "PDC",
                table: "KanbanBoard");

            migrationBuilder.RenameTable(
                name: "TaskItem",
                schema: "PDC",
                newName: "TaskItems",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TaskInKanban",
                schema: "PDC",
                newName: "TaskInKanbans",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Sprint",
                schema: "PDC",
                newName: "Sprints",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "KanbanBoard",
                schema: "PDC",
                newName: "KanbanBoards",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_UserInTeamId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_UserInTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_TaskTypeId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_PriorityId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_OrganizationalRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_DepartmentId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItem_AuditId",
                schema: "PDC",
                table: "TaskItems",
                newName: "IX_TaskItems_AuditId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanban_TaskItemId",
                schema: "PDC",
                table: "TaskInKanbans",
                newName: "IX_TaskInKanbans_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanban_SprintId1",
                schema: "PDC",
                table: "TaskInKanbans",
                newName: "IX_TaskInKanbans_SprintId1");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanban_SprintId",
                schema: "PDC",
                table: "TaskInKanbans",
                newName: "IX_TaskInKanbans_SprintId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanban_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanbans",
                newName: "IX_TaskInKanbans_LocationInKanbanId");

            migrationBuilder.RenameIndex(
                name: "IX_Sprint_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprints",
                newName: "IX_Sprints_KanbanBoardKanbanId");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanBoard_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards",
                newName: "IX_KanbanBoards_ProjectItemId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "PDC",
                table: "TaskItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AuditId",
                schema: "PDC",
                table: "TaskItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItems",
                schema: "PDC",
                table: "TaskItems",
                column: "TaskItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskInKanbans",
                schema: "PDC",
                table: "TaskInKanbans",
                columns: new[] { "KanbanBoardId", "LocationInKanbanId", "TaskItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprints",
                schema: "PDC",
                table: "Sprints",
                column: "SprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanBoards",
                schema: "PDC",
                table: "KanbanBoards",
                column: "KanbanId");

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
                name: "FK_Sprints_KanbanBoards_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprints",
                column: "KanbanBoardKanbanId",
                principalSchema: "PDC",
                principalTable: "KanbanBoards",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanbans_KanbanBoards_KanbanBoardId",
                schema: "PDC",
                table: "TaskInKanbans",
                column: "KanbanBoardId",
                principalSchema: "PDC",
                principalTable: "KanbanBoards",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanbans_LocationInKanbans_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanbans",
                column: "LocationInKanbanId",
                principalSchema: "PDC",
                principalTable: "LocationInKanbans",
                principalColumn: "LocationInKanbanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanbans_Sprints_SprintId",
                schema: "PDC",
                table: "TaskInKanbans",
                column: "SprintId",
                principalSchema: "PDC",
                principalTable: "Sprints",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanbans_Sprints_SprintId1",
                schema: "PDC",
                table: "TaskInKanbans",
                column: "SprintId1",
                principalSchema: "PDC",
                principalTable: "Sprints",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanbans_TaskItems_TaskItemId",
                schema: "PDC",
                table: "TaskInKanbans",
                column: "TaskItemId",
                principalSchema: "PDC",
                principalTable: "TaskItems",
                principalColumn: "TaskItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Audits_AuditId",
                schema: "PDC",
                table: "TaskItems",
                column: "AuditId",
                principalSchema: "PDC",
                principalTable: "Audits",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Departments_DepartmentId",
                schema: "PDC",
                table: "TaskItems",
                column: "DepartmentId",
                principalSchema: "PDC",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItems",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Priority_PriorityId",
                schema: "PDC",
                table: "TaskItems",
                column: "PriorityId",
                principalSchema: "PDC",
                principalTable: "Priority",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_TaskTypes_TaskTypeId",
                schema: "PDC",
                table: "TaskItems",
                column: "TaskTypeId",
                principalSchema: "PDC",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "TaskItems",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KanbanBoards_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoards");

            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_KanbanBoards_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprints");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanbans_KanbanBoards_KanbanBoardId",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanbans_LocationInKanbans_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanbans_Sprints_SprintId",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanbans_Sprints_SprintId1",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInKanbans_TaskItems_TaskItemId",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Audits_AuditId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Departments_DepartmentId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Priority_PriorityId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_TaskTypes_TaskTypeId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskItems",
                schema: "PDC",
                table: "TaskItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskInKanbans",
                schema: "PDC",
                table: "TaskInKanbans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sprints",
                schema: "PDC",
                table: "Sprints");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KanbanBoards",
                schema: "PDC",
                table: "KanbanBoards");

            migrationBuilder.RenameTable(
                name: "TaskItems",
                schema: "PDC",
                newName: "TaskItem",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TaskInKanbans",
                schema: "PDC",
                newName: "TaskInKanban",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Sprints",
                schema: "PDC",
                newName: "Sprint",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "KanbanBoards",
                schema: "PDC",
                newName: "KanbanBoard",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_UserInTeamId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_UserInTeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_TaskTypeId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_TaskTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_PriorityId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_PriorityId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_OrganizationalRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_DepartmentId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskItems_AuditId",
                schema: "PDC",
                table: "TaskItem",
                newName: "IX_TaskItem_AuditId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanbans_TaskItemId",
                schema: "PDC",
                table: "TaskInKanban",
                newName: "IX_TaskInKanban_TaskItemId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanbans_SprintId1",
                schema: "PDC",
                table: "TaskInKanban",
                newName: "IX_TaskInKanban_SprintId1");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanbans_SprintId",
                schema: "PDC",
                table: "TaskInKanban",
                newName: "IX_TaskInKanban_SprintId");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInKanbans_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanban",
                newName: "IX_TaskInKanban_LocationInKanbanId");

            migrationBuilder.RenameIndex(
                name: "IX_Sprints_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprint",
                newName: "IX_Sprint_KanbanBoardKanbanId");

            migrationBuilder.RenameIndex(
                name: "IX_KanbanBoards_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoard",
                newName: "IX_KanbanBoard_ProjectItemId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                schema: "PDC",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuditId",
                schema: "PDC",
                table: "TaskItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskItem",
                schema: "PDC",
                table: "TaskItem",
                column: "TaskItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskInKanban",
                schema: "PDC",
                table: "TaskInKanban",
                columns: new[] { "KanbanBoardId", "LocationInKanbanId", "TaskItemId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sprint",
                schema: "PDC",
                table: "Sprint",
                column: "SprintId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KanbanBoard",
                schema: "PDC",
                table: "KanbanBoard",
                column: "KanbanId");

            migrationBuilder.AddForeignKey(
                name: "FK_KanbanBoard_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoard",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sprint_KanbanBoard_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprint",
                column: "KanbanBoardKanbanId",
                principalSchema: "PDC",
                principalTable: "KanbanBoard",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanban_KanbanBoard_KanbanBoardId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "KanbanBoardId",
                principalSchema: "PDC",
                principalTable: "KanbanBoard",
                principalColumn: "KanbanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanban_LocationInKanbans_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "LocationInKanbanId",
                principalSchema: "PDC",
                principalTable: "LocationInKanbans",
                principalColumn: "LocationInKanbanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanban_Sprint_SprintId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "SprintId",
                principalSchema: "PDC",
                principalTable: "Sprint",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanban_Sprint_SprintId1",
                schema: "PDC",
                table: "TaskInKanban",
                column: "SprintId1",
                principalSchema: "PDC",
                principalTable: "Sprint",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInKanban_TaskItem_TaskItemId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "TaskItemId",
                principalSchema: "PDC",
                principalTable: "TaskItem",
                principalColumn: "TaskItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Audits_AuditId",
                schema: "PDC",
                table: "TaskItem",
                column: "AuditId",
                principalSchema: "PDC",
                principalTable: "Audits",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Departments_DepartmentId",
                schema: "PDC",
                table: "TaskItem",
                column: "DepartmentId",
                principalSchema: "PDC",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Priority_PriorityId",
                schema: "PDC",
                table: "TaskItem",
                column: "PriorityId",
                principalSchema: "PDC",
                principalTable: "Priority",
                principalColumn: "PriorityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_TaskTypes_TaskTypeId",
                schema: "PDC",
                table: "TaskItem",
                column: "TaskTypeId",
                principalSchema: "PDC",
                principalTable: "TaskTypes",
                principalColumn: "TaskTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "TaskItem",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
