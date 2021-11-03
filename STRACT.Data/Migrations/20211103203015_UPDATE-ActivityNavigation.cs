using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATEActivityNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityFunctionalRole",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivityOrganizationalRole",
                schema: "PDC");

            migrationBuilder.AddColumn<int>(
                name: "FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActivityInFunctionalRoles",
                schema: "PDC",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    FunctionalRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInFunctionalRoles", x => new { x.FunctionalRoleId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_ActivityInFunctionalRoles_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInFunctionalRoles_FuntionalRoles_FunctionalRoleId",
                        column: x => x.FunctionalRoleId,
                        principalSchema: "PDC",
                        principalTable: "FuntionalRoles",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInOrganizationalRole",
                schema: "PDC",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    OrganizationalRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInOrganizationalRole", x => new { x.OrganizationalRoleId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_ActivityInOrganizationalRole_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInOrganizationalRole_OrganizationalRoles_OrganizationalRoleId",
                        column: x => x.OrganizationalRoleId,
                        principalSchema: "PDC",
                        principalTable: "OrganizationalRoles",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "OrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInFunctionalRoles_ActivityId",
                schema: "PDC",
                table: "ActivityInFunctionalRoles",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInOrganizationalRole_ActivityId",
                schema: "PDC",
                table: "ActivityInOrganizationalRole",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "FunctionalRoleId",
                principalSchema: "PDC",
                principalTable: "FuntionalRoles",
                principalColumn: "FunctionalRoleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities",
                column: "OrganizationalRoleId",
                principalSchema: "PDC",
                principalTable: "OrganizationalRoles",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_FuntionalRoles_FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_OrganizationalRoles_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropTable(
                name: "ActivityInFunctionalRoles",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivityInOrganizationalRole",
                schema: "PDC");

            migrationBuilder.DropIndex(
                name: "IX_Activities_FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "FunctionalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "OrganizationalRoleId",
                schema: "PDC",
                table: "Activities");

            migrationBuilder.CreateTable(
                name: "ActivityFunctionalRole",
                schema: "PDC",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    FunctionalRolesFunctionalRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityFunctionalRole", x => new { x.ActivitiesActivityId, x.FunctionalRolesFunctionalRoleId });
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_FuntionalRoles_FunctionalRolesFunctionalRoleId",
                        column: x => x.FunctionalRolesFunctionalRoleId,
                        principalSchema: "PDC",
                        principalTable: "FuntionalRoles",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOrganizationalRole",
                schema: "PDC",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    OrganizationalRolesOrganizationalRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityOrganizationalRole", x => new { x.ActivitiesActivityId, x.OrganizationalRolesOrganizationalRoleId });
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_OrganizationalRoles_OrganizationalRolesOrganizationalRoleId",
                        column: x => x.OrganizationalRolesOrganizationalRoleId,
                        principalSchema: "PDC",
                        principalTable: "OrganizationalRoles",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFunctionalRole_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId");
        }
    }
}
