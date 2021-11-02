using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATE202110292113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityFunctionalRole_FunctionalRole_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityOrganizationalRole_OrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMember_FunctionalRole_FunctionalRoleId",
                schema: "PDC",
                table: "ProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_OrganizationalRole_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInTeam_OrganizationalRole_OrganizationalRoleId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalRole",
                schema: "PDC",
                table: "OrganizationalRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FunctionalRole",
                schema: "PDC",
                table: "FunctionalRole");

            migrationBuilder.RenameTable(
                name: "OrganizationalRole",
                schema: "PDC",
                newName: "OrganizationalRoles",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FunctionalRole",
                schema: "PDC",
                newName: "FuntionalRoles",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalRoles",
                schema: "PDC",
                table: "OrganizationalRoles",
                column: "OrganizationalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuntionalRoles",
                schema: "PDC",
                table: "FuntionalRoles",
                column: "FunctionalRoleId");

            migrationBuilder.CreateTable(
                name: "SkillInActivity",
                schema: "PDC",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    RequestedScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillInActivity", x => new { x.SkillId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_SkillInActivity_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillInActivity_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "PDC",
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillInActivity_ActivityId",
                schema: "PDC",
                table: "SkillInActivity",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityFunctionalRole_FuntionalRoles_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FuntionalRoles",
                principalColumn: "FunctionalRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityOrganizationalRole_OrganizationalRoles_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMember_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "ProjectMember",
                column: "FunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FuntionalRoles",
                principalColumn: "FunctionalRoleId",
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
                name: "FK_UserInTeam_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "UserInTeam",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityFunctionalRole_FuntionalRoles_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityOrganizationalRole_OrganizationalRoles_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectMember_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "ProjectMember");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInTeam_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "UserInTeam");

            migrationBuilder.DropTable(
                name: "SkillInActivity",
                schema: "PDC");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalRoles",
                schema: "PDC",
                table: "OrganizationalRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FuntionalRoles",
                schema: "PDC",
                table: "FuntionalRoles");

            migrationBuilder.RenameTable(
                name: "OrganizationalRoles",
                schema: "PDC",
                newName: "OrganizationalRole",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FuntionalRoles",
                schema: "PDC",
                newName: "FunctionalRole",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalRole",
                schema: "PDC",
                table: "OrganizationalRole",
                column: "OrganizationalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FunctionalRole",
                schema: "PDC",
                table: "FunctionalRole",
                column: "FunctionalRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityFunctionalRole_FunctionalRole_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FunctionalRole",
                principalColumn: "FunctionalRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityOrganizationalRole_OrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRole",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectMember_FunctionalRole_FunctionalRoleId",
                schema: "PDC",
                table: "ProjectMember",
                column: "FunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FunctionalRole",
                principalColumn: "FunctionalRoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_OrganizationalRole_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRole",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInTeam_OrganizationalRole_OrganizationalRoleId",
                schema: "PDC",
                table: "UserInTeam",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRole",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
