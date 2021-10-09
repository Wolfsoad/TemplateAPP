using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGroups",
                columns: table => new
                {
                    ActivityGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGroups", x => x.ActivityGroupId);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalRole",
                columns: table => new
                {
                    FunctionalRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRole", x => x.FunctionalRoleId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalRole",
                columns: table => new
                {
                    OrganizationalRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalRole", x => x.OrganizationalRoleId);
                });

            migrationBuilder.CreateTable(
                name: "SkillGroup",
                columns: table => new
                {
                    SkillGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillGroup", x => x.SkillGroupId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInGroups",
                columns: table => new
                {
                    ActivityGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActivityGroupId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInGroups", x => x.ActivityGroupId);
                    table.ForeignKey(
                        name: "FK_ActivityInGroups_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInGroups_ActivityGroups_ActivityGroupId1",
                        column: x => x.ActivityGroupId1,
                        principalTable: "ActivityGroups",
                        principalColumn: "ActivityGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityFunctionalRole",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    FunctionalRolesFunctionalRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityFunctionalRole", x => new { x.ActivitiesActivityId, x.FunctionalRolesFunctionalRoleId });
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_FunctionalRole_FunctionalRolesFunctionalRoleId",
                        column: x => x.FunctionalRolesFunctionalRoleId,
                        principalTable: "FunctionalRole",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOrganizationalRole",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationalRolesOrganizationalRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOrganizationalRole", x => new { x.ActivitiesActivityId, x.OrganizationalRolesOrganizationalRoleId });
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_OrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                        column: x => x.OrganizationalRolesOrganizationalRoleId,
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    SkillGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skill_SkillGroup_SkillGroupId",
                        column: x => x.SkillGroupId,
                        principalTable: "SkillGroup",
                        principalColumn: "SkillGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySkill",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySkill", x => new { x.ActivitiesActivityId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Skill_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFunctionalRole_FunctionalRolesFunctionalRoleId",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroups_ActivityGroupId1",
                table: "ActivityInGroups",
                column: "ActivityGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroups_ActivityId",
                table: "ActivityInGroups",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySkill_SkillsSkillId",
                table: "ActivitySkill",
                column: "SkillsSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillGroupId",
                table: "Skill",
                column: "SkillGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityFunctionalRole");

            migrationBuilder.DropTable(
                name: "ActivityInGroups");

            migrationBuilder.DropTable(
                name: "ActivityOrganizationalRole");

            migrationBuilder.DropTable(
                name: "ActivitySkill");

            migrationBuilder.DropTable(
                name: "FunctionalRole");

            migrationBuilder.DropTable(
                name: "ActivityGroups");

            migrationBuilder.DropTable(
                name: "OrganizationalRole");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "SkillGroup");
        }
    }
}
