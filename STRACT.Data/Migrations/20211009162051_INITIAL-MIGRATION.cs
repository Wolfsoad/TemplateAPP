using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class INITIALMIGRATION : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PDC");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "ActionGroup",
                schema: "PDC",
                columns: table => new
                {
                    ActionGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionGroup", x => x.ActionGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                schema: "PDC",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGroup",
                schema: "PDC",
                columns: table => new
                {
                    ActivityGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGroup", x => x.ActivityGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AlertType",
                schema: "PDC",
                columns: table => new
                {
                    AlertTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertType", x => x.AlertTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "PDC",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                schema: "PDC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AffectedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChronogramText",
                schema: "PDC",
                columns: table => new
                {
                    ChronogramTextId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repeatable = table.Column<bool>(type: "bit", nullable: false),
                    Milestone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronogramText", x => x.ChronogramTextId);
                });

            migrationBuilder.CreateTable(
                name: "Commission",
                schema: "PDC",
                columns: table => new
                {
                    CommissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.CommissionId);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "PDC",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "PDC",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                schema: "PDC",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialLineSubType",
                schema: "PDC",
                columns: table => new
                {
                    FinancialLineSubTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialLineSubType", x => x.FinancialLineSubTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialLineType",
                schema: "PDC",
                columns: table => new
                {
                    FinancialLineTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialLineType", x => x.FinancialLineTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FunctionalRole",
                schema: "PDC",
                columns: table => new
                {
                    FunctionalRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionalRole", x => x.FunctionalRoleId);
                });

            migrationBuilder.CreateTable(
                name: "LineOfProduct",
                schema: "PDC",
                columns: table => new
                {
                    LineOfProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineOfProduct", x => x.LineOfProductId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "PDC",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "LocationInKanban",
                schema: "PDC",
                columns: table => new
                {
                    LocationInKanbanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationInKanban", x => x.LocationInKanbanId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalRole",
                schema: "PDC",
                columns: table => new
                {
                    OrganizationalRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalRole", x => x.OrganizationalRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "PDC",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                });

            migrationBuilder.CreateTable(
                name: "ProposalStatus",
                schema: "PDC",
                columns: table => new
                {
                    ProposalStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalStatus", x => x.ProposalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillGroup",
                schema: "PDC",
                columns: table => new
                {
                    SkillGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillGroup", x => x.SkillGroupId);
                });

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                schema: "PDC",
                columns: table => new
                {
                    TaskTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.TaskTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                schema: "PDC",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInGroup",
                schema: "PDC",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId1 = table.Column<int>(type: "int", nullable: false),
                    ActivityGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInGroup", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_ActivityInGroup_Activity_ActivityId1",
                        column: x => x.ActivityId1,
                        principalSchema: "PDC",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInGroup_ActivityGroup_ActivityGroupId",
                        column: x => x.ActivityGroupId,
                        principalSchema: "PDC",
                        principalTable: "ActivityGroup",
                        principalColumn: "ActivityGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsernameChangeLimit = table.Column<int>(type: "int", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_AspNetUsers_Id",
                        column: x => x.Id,
                        principalSchema: "PDC",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionForProject",
                schema: "PDC",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionId = table.Column<int>(type: "int", nullable: false),
                    Proposal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportDocuments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Advantages = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionForProject", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_CommissionForProject_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalSchema: "PDC",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationLine",
                schema: "PDC",
                columns: table => new
                {
                    CertificationLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryAudit = table.Column<bool>(type: "bit", nullable: false),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditFrequency = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLine", x => x.CertificationLineId);
                    table.ForeignKey(
                        name: "FK_CertificationLine_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "PDC",
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPerson",
                schema: "PDC",
                columns: table => new
                {
                    ContactPersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMainContact = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPerson", x => x.ContactPersonId);
                    table.ForeignKey(
                        name: "FK_ContactPerson_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "PDC",
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_ActivityFunctionalRole_Activity_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_FunctionalRole_FunctionalRolesFunctionalRoleId",
                        column: x => x.FunctionalRolesFunctionalRoleId,
                        principalSchema: "PDC",
                        principalTable: "FunctionalRole",
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
                        name: "FK_ActivityOrganizationalRole_Activity_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_OrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                        column: x => x.OrganizationalRolesOrganizationalRoleId,
                        principalSchema: "PDC",
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decision",
                schema: "PDC",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Minutes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDecision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    CommissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_Decision_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalSchema: "PDC",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decision_ProposalStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "PDC",
                        principalTable: "ProposalStatus",
                        principalColumn: "ProposalStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "PDC",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SkillGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skill_SkillGroup_SkillGroupId",
                        column: x => x.SkillGroupId,
                        principalSchema: "PDC",
                        principalTable: "SkillGroup",
                        principalColumn: "SkillGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInTeam",
                schema: "PDC",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationalRoleId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInTeam", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserInTeam_OrganizationalRole_OrganizationalRoleId",
                        column: x => x.OrganizationalRoleId,
                        principalSchema: "PDC",
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInTeam_User_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                schema: "PDC",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CertificateUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CertificationLineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificate_CertificationLine_CertificationLineId",
                        column: x => x.CertificationLineId,
                        principalSchema: "PDC",
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySkill",
                schema: "PDC",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySkill", x => new { x.ActivitiesActivityId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Activity_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "PDC",
                        principalTable: "Activity",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Skill_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalSchema: "PDC",
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "PDC",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    DateOfAudit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Concluded = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CertificationLineId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Audit_CertificationLine_CertificationLineId",
                        column: x => x.CertificationLineId,
                        principalSchema: "PDC",
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "PDC",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationItem",
                schema: "PDC",
                columns: table => new
                {
                    DeclarationItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationItem", x => x.DeclarationItemId);
                    table.ForeignKey(
                        name: "FK_DeclarationItem_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectItem",
                schema: "PDC",
                columns: table => new
                {
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailOfProblem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MappedBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpectedResults = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConceptsDeveloped = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainConclusions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CoordinatorUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectItem", x => x.ProjectItemId);
                    table.ForeignKey(
                        name: "FK_ProjectItem_UserInTeam_CoordinatorUserId",
                        column: x => x.CoordinatorUserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                schema: "PDC",
                columns: table => new
                {
                    ProposalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Proposal_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalSchema: "PDC",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposal_UserInTeam_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProductLines",
                schema: "PDC",
                columns: table => new
                {
                    ProductLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateId = table.Column<int>(type: "int", nullable: false),
                    LineOfProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateProductLines", x => x.ProductLineId);
                    table.ForeignKey(
                        name: "FK_CertificateProductLines_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalSchema: "PDC",
                        principalTable: "Certificate",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateProductLines_LineOfProduct_LineOfProductId",
                        column: x => x.LineOfProductId,
                        principalSchema: "PDC",
                        principalTable: "LineOfProduct",
                        principalColumn: "LineOfProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                schema: "PDC",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureActivity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<double>(type: "float", nullable: false),
                    IsRepeatable = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResponsibleUserId = table.Column<int>(type: "int", nullable: true),
                    OrganizationRoleId = table.Column<int>(type: "int", nullable: false),
                    OrganizationalRoleId = table.Column<int>(type: "int", nullable: true),
                    TaskTypeId = table.Column<int>(type: "int", nullable: false),
                    AuditId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_TaskItem_Audit_AuditId",
                        column: x => x.AuditId,
                        principalSchema: "PDC",
                        principalTable: "Audit",
                        principalColumn: "AuditId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItem_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalSchema: "PDC",
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItem_OrganizationalRole_OrganizationalRoleId",
                        column: x => x.OrganizationalRoleId,
                        principalSchema: "PDC",
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskItem_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "PDC",
                        principalTable: "Priority",
                        principalColumn: "PriorityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItem_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalSchema: "PDC",
                        principalTable: "TaskTypes",
                        principalColumn: "TaskTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItem_UserInTeam_ResponsibleUserId",
                        column: x => x.ResponsibleUserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationRevision",
                schema: "PDC",
                columns: table => new
                {
                    DeclarationRevisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DeclarationItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationRevision", x => x.DeclarationRevisionId);
                    table.ForeignKey(
                        name: "FK_DeclarationRevision_DeclarationItem_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalSchema: "PDC",
                        principalTable: "DeclarationItem",
                        principalColumn: "DeclarationItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationRevision_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationSignature",
                schema: "PDC",
                columns: table => new
                {
                    SignatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclarationItemId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationSignature", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_DeclarationSignature_DeclarationItem_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalSchema: "PDC",
                        principalTable: "DeclarationItem",
                        principalColumn: "DeclarationItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationSignature_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlertInProject",
                schema: "PDC",
                columns: table => new
                {
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlertTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectItemId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertInProject", x => x.ProjectItemId);
                    table.ForeignKey(
                        name: "FK_AlertInProject_AlertType_AlertTypeId",
                        column: x => x.AlertTypeId,
                        principalSchema: "PDC",
                        principalTable: "AlertType",
                        principalColumn: "AlertTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertInProject_ProjectItem_ProjectItemId1",
                        column: x => x.ProjectItemId1,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChronogramRevision",
                schema: "PDC",
                columns: table => new
                {
                    ChronogramRevisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronogramRevision", x => x.ChronogramRevisionId);
                    table.ForeignKey(
                        name: "FK_ChronogramRevision_ProjectItem_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChronogramRevision_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KanbanBoard",
                schema: "PDC",
                columns: table => new
                {
                    KanbanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoard", x => x.KanbanId);
                    table.ForeignKey(
                        name: "FK_KanbanBoard_ProjectItem_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                schema: "PDC",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectItemId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    FunctionalRoleId = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfFunction = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMember", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_ProjectMember_FunctionalRole_FunctionalRoleId",
                        column: x => x.FunctionalRoleId,
                        principalSchema: "PDC",
                        principalTable: "FunctionalRole",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMember_ProjectItem_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectMember_UserInTeam_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicInProject",
                schema: "PDC",
                columns: table => new
                {
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    ProjectItemId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicInProject", x => x.ProjectItemId);
                    table.ForeignKey(
                        name: "FK_TopicInProject_ProjectItem_ProjectItemId1",
                        column: x => x.ProjectItemId1,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicInProject_Topic_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "PDC",
                        principalTable: "Topic",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionPlanRevision",
                schema: "PDC",
                columns: table => new
                {
                    ActionPlanRevisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevisionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Budget = table.Column<double>(type: "float", nullable: false),
                    ActionPlanYear = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProposalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlanRevision", x => x.ActionPlanRevisionId);
                    table.ForeignKey(
                        name: "FK_ActionPlanRevision_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalSchema: "PDC",
                        principalTable: "Proposal",
                        principalColumn: "ProposalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActionPlanRevision_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChronogramLine",
                schema: "PDC",
                columns: table => new
                {
                    ChronogramLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlannedStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    EffectiveStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PercentOfConclusion = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ChronogramTextId = table.Column<int>(type: "int", nullable: false),
                    ChronogramRevisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronogramLine", x => x.ChronogramLineId);
                    table.ForeignKey(
                        name: "FK_ChronogramLine_ChronogramRevision_ChronogramRevisionId",
                        column: x => x.ChronogramRevisionId,
                        principalSchema: "PDC",
                        principalTable: "ChronogramRevision",
                        principalColumn: "ChronogramRevisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChronogramLine_ChronogramText_ChronogramTextId",
                        column: x => x.ChronogramTextId,
                        principalSchema: "PDC",
                        principalTable: "ChronogramText",
                        principalColumn: "ChronogramTextId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                schema: "PDC",
                columns: table => new
                {
                    SprintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationInDays = table.Column<int>(type: "int", nullable: false),
                    PointsRequired = table.Column<int>(type: "int", nullable: false),
                    PointsDone = table.Column<int>(type: "int", nullable: false),
                    KanbanBoardKanbanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.SprintId);
                    table.ForeignKey(
                        name: "FK_Sprint_KanbanBoard_KanbanBoardKanbanId",
                        column: x => x.KanbanBoardKanbanId,
                        principalSchema: "PDC",
                        principalTable: "KanbanBoard",
                        principalColumn: "KanbanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionItem",
                schema: "PDC",
                columns: table => new
                {
                    ActionItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActionGroupId = table.Column<int>(type: "int", nullable: false),
                    ActionPlanRevisionId = table.Column<int>(type: "int", nullable: false),
                    ProjectItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItem", x => x.ActionItemId);
                    table.ForeignKey(
                        name: "FK_ActionItem_ActionGroup_ActionGroupId",
                        column: x => x.ActionGroupId,
                        principalSchema: "PDC",
                        principalTable: "ActionGroup",
                        principalColumn: "ActionGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                        column: x => x.ActionPlanRevisionId,
                        principalSchema: "PDC",
                        principalTable: "ActionPlanRevision",
                        principalColumn: "ActionPlanRevisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionItem_ProjectItem_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskInKanban",
                schema: "PDC",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "int", nullable: false),
                    KanbanBoardId = table.Column<int>(type: "int", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: true),
                    LocationInKanbanId = table.Column<int>(type: "int", nullable: false),
                    SprintId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInKanban", x => x.TaskItemId);
                    table.ForeignKey(
                        name: "FK_TaskInKanban_KanbanBoard_KanbanBoardId",
                        column: x => x.KanbanBoardId,
                        principalSchema: "PDC",
                        principalTable: "KanbanBoard",
                        principalColumn: "KanbanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInKanban_LocationInKanban_LocationInKanbanId",
                        column: x => x.LocationInKanbanId,
                        principalSchema: "PDC",
                        principalTable: "LocationInKanban",
                        principalColumn: "LocationInKanbanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInKanban_Sprint_SprintId",
                        column: x => x.SprintId,
                        principalSchema: "PDC",
                        principalTable: "Sprint",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskInKanban_Sprint_SprintId1",
                        column: x => x.SprintId1,
                        principalSchema: "PDC",
                        principalTable: "Sprint",
                        principalColumn: "SprintId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskInKanban_TaskItem_TaskItemId",
                        column: x => x.TaskItemId,
                        principalSchema: "PDC",
                        principalTable: "TaskItem",
                        principalColumn: "TaskItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionItemLineOfProduct",
                schema: "PDC",
                columns: table => new
                {
                    ActionItemsActionItemId = table.Column<int>(type: "int", nullable: false),
                    LinesOfProductsLineOfProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItemLineOfProduct", x => new { x.ActionItemsActionItemId, x.LinesOfProductsLineOfProductId });
                    table.ForeignKey(
                        name: "FK_ActionItemLineOfProduct_ActionItem_ActionItemsActionItemId",
                        column: x => x.ActionItemsActionItemId,
                        principalSchema: "PDC",
                        principalTable: "ActionItem",
                        principalColumn: "ActionItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionItemLineOfProduct_LineOfProduct_LinesOfProductsLineOfProductId",
                        column: x => x.LinesOfProductsLineOfProductId,
                        principalSchema: "PDC",
                        principalTable: "LineOfProduct",
                        principalColumn: "LineOfProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationInActionItems",
                schema: "PDC",
                columns: table => new
                {
                    CertificationLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionItemId = table.Column<int>(type: "int", nullable: false),
                    CertificationLineId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationInActionItems", x => x.CertificationLineId);
                    table.ForeignKey(
                        name: "FK_CertificationInActionItems_ActionItem_ActionItemId",
                        column: x => x.ActionItemId,
                        principalSchema: "PDC",
                        principalTable: "ActionItem",
                        principalColumn: "ActionItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationInActionItems_CertificationLine_CertificationLineId1",
                        column: x => x.CertificationLineId1,
                        principalSchema: "PDC",
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialLine",
                schema: "PDC",
                columns: table => new
                {
                    FinancialLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvestmentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpenseAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BudgetValue = table.Column<double>(type: "float", nullable: false),
                    AdjudicatedValueOriginalCurrency = table.Column<double>(type: "float", nullable: false),
                    ExchangeRateToEuro = table.Column<double>(type: "float", nullable: false),
                    AccountedValue = table.Column<double>(type: "float", nullable: false),
                    Claim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Invoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceAcceptance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ActionItemId = table.Column<int>(type: "int", nullable: false),
                    ProposalId = table.Column<int>(type: "int", nullable: false),
                    FinancialLineTypeId = table.Column<int>(type: "int", nullable: false),
                    FinancialLineSubtypeId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialLine", x => x.FinancialLineId);
                    table.ForeignKey(
                        name: "FK_FinancialLine_ActionItem_ActionItemId",
                        column: x => x.ActionItemId,
                        principalSchema: "PDC",
                        principalTable: "ActionItem",
                        principalColumn: "ActionItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialLine_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "PDC",
                        principalTable: "Currency",
                        principalColumn: "CurrencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialLine_FinancialLineSubType_FinancialLineSubtypeId",
                        column: x => x.FinancialLineSubtypeId,
                        principalSchema: "PDC",
                        principalTable: "FinancialLineSubType",
                        principalColumn: "FinancialLineSubTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialLine_FinancialLineType_FinancialLineTypeId",
                        column: x => x.FinancialLineTypeId,
                        principalSchema: "PDC",
                        principalTable: "FinancialLineType",
                        principalColumn: "FinancialLineTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialLine_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "PDC",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinancialLine_Proposal_ProposalId",
                        column: x => x.ProposalId,
                        principalSchema: "PDC",
                        principalTable: "Proposal",
                        principalColumn: "ProposalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationsForAction",
                schema: "PDC",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId1 = table.Column<int>(type: "int", nullable: false),
                    ActionLineId = table.Column<int>(type: "int", nullable: false),
                    ActionItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationsForAction", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_LocationsForAction_ActionItem_ActionItemId",
                        column: x => x.ActionItemId,
                        principalSchema: "PDC",
                        principalTable: "ActionItem",
                        principalColumn: "ActionItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocationsForAction_Location_LocationId1",
                        column: x => x.LocationId1,
                        principalSchema: "PDC",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoTask",
                schema: "PDC",
                columns: table => new
                {
                    ToDoTaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsConcluded = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    ActionItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoTask", x => x.ToDoTaskId);
                    table.ForeignKey(
                        name: "FK_ToDoTask_ActionItem_ActionItemId",
                        column: x => x.ActionItemId,
                        principalSchema: "PDC",
                        principalTable: "ActionItem",
                        principalColumn: "ActionItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoTask_ProjectItem_ProjectItemId",
                        column: x => x.ProjectItemId,
                        principalSchema: "PDC",
                        principalTable: "ProjectItem",
                        principalColumn: "ProjectItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToDoTask_UserInTeam_UserId",
                        column: x => x.UserId,
                        principalSchema: "PDC",
                        principalTable: "UserInTeam",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_ActionGroupId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionPlanRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItemLineOfProduct_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct",
                column: "LinesOfProductsLineOfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlanRevision_ProposalId",
                schema: "PDC",
                table: "ActionPlanRevision",
                column: "ProposalId",
                unique: true,
                filter: "[ProposalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlanRevision_UserId",
                schema: "PDC",
                table: "ActionPlanRevision",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFunctionalRole_FunctionalRolesFunctionalRoleId",
                schema: "PDC",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroup_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroup_ActivityId1",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                schema: "PDC",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySkill_SkillsSkillId",
                schema: "PDC",
                table: "ActivitySkill",
                column: "SkillsSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertInProject_AlertTypeId",
                schema: "PDC",
                table: "AlertInProject",
                column: "AlertTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertInProject_ProjectItemId1",
                schema: "PDC",
                table: "AlertInProject",
                column: "ProjectItemId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "PDC",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "PDC",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CertificationLineId",
                schema: "PDC",
                table: "Audit",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LocationId",
                schema: "PDC",
                table: "Audit",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_UserId",
                schema: "PDC",
                table: "Audit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CertificationLineId",
                schema: "PDC",
                table: "Certificate",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_CertificateId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_LineOfProductId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "LineOfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationInActionItems_ActionItemId",
                schema: "PDC",
                table: "CertificationInActionItems",
                column: "ActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationInActionItems_CertificationLineId1",
                schema: "PDC",
                table: "CertificationInActionItems",
                column: "CertificationLineId1");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationLine_EntityId",
                schema: "PDC",
                table: "CertificationLine",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramLine_ChronogramRevisionId",
                schema: "PDC",
                table: "ChronogramLine",
                column: "ChronogramRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramLine_ChronogramTextId",
                schema: "PDC",
                table: "ChronogramLine",
                column: "ChronogramTextId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramRevision_ProjectItemId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronogramRevision_UserId",
                schema: "PDC",
                table: "ChronogramRevision",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionForProject_CommissionId",
                schema: "PDC",
                table: "CommissionForProject",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPerson_EntityId",
                schema: "PDC",
                table: "ContactPerson",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_CommissionId",
                schema: "PDC",
                table: "Decision",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_StatusId",
                schema: "PDC",
                table: "Decision",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationItem_UserId",
                schema: "PDC",
                table: "DeclarationItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "DeclarationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_UserId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignature_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignature",
                column: "DeclarationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignature_UserId",
                schema: "PDC",
                table: "DeclarationSignature",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_ActionItemId",
                schema: "PDC",
                table: "FinancialLine",
                column: "ActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_CurrencyId",
                schema: "PDC",
                table: "FinancialLine",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_FinancialLineSubtypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineSubtypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_FinancialLineTypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_LocationId",
                schema: "PDC",
                table: "FinancialLine",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialLine_ProposalId",
                schema: "PDC",
                table: "FinancialLine",
                column: "ProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_KanbanBoard_ProjectItemId",
                schema: "PDC",
                table: "KanbanBoard",
                column: "ProjectItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationsForAction_ActionItemId",
                schema: "PDC",
                table: "LocationsForAction",
                column: "ActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationsForAction_LocationId1",
                schema: "PDC",
                table: "LocationsForAction",
                column: "LocationId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectItem_CoordinatorUserId",
                schema: "PDC",
                table: "ProjectItem",
                column: "CoordinatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_FunctionalRoleId",
                schema: "PDC",
                table: "ProjectMember",
                column: "FunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_ProjectItemId",
                schema: "PDC",
                table: "ProjectMember",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_UserId1",
                schema: "PDC",
                table: "ProjectMember",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_CommissionId",
                schema: "PDC",
                table: "Proposal",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_ResponsibleUserId",
                schema: "PDC",
                table: "Proposal",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillGroupId",
                schema: "PDC",
                table: "Skill",
                column: "SkillGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_KanbanBoardKanbanId",
                schema: "PDC",
                table: "Sprint",
                column: "KanbanBoardKanbanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInKanban_KanbanBoardId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "KanbanBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInKanban_LocationInKanbanId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "LocationInKanbanId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInKanban_SprintId",
                schema: "PDC",
                table: "TaskInKanban",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInKanban_SprintId1",
                schema: "PDC",
                table: "TaskInKanban",
                column: "SprintId1");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_AuditId",
                schema: "PDC",
                table: "TaskItem",
                column: "AuditId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_DepartmentId",
                schema: "PDC",
                table: "TaskItem",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_OrganizationalRoleId",
                schema: "PDC",
                table: "TaskItem",
                column: "OrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_PriorityId",
                schema: "PDC",
                table: "TaskItem",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_ResponsibleUserId",
                schema: "PDC",
                table: "TaskItem",
                column: "ResponsibleUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_TaskTypeId",
                schema: "PDC",
                table: "TaskItem",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_ActionItemId",
                schema: "PDC",
                table: "ToDoTask",
                column: "ActionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_ProjectItemId",
                schema: "PDC",
                table: "ToDoTask",
                column: "ProjectItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoTask_UserId",
                schema: "PDC",
                table: "ToDoTask",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicInProject_ProjectItemId1",
                schema: "PDC",
                table: "TopicInProject",
                column: "ProjectItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_TopicInProject_TopicId",
                schema: "PDC",
                table: "TopicInProject",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_ApplicationUserId1",
                schema: "PDC",
                table: "UserInTeam",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserInTeam_OrganizationalRoleId",
                schema: "PDC",
                table: "UserInTeam",
                column: "OrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItemLineOfProduct",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivityFunctionalRole",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivityInGroup",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivityOrganizationalRole",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActivitySkill",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "AlertInProject",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "AuditLogs",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "CertificateProductLines",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "CertificationInActionItems",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ChronogramLine",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "CommissionForProject",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ContactPerson",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Decision",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "DeclarationRevision",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "DeclarationSignature",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "FinancialLine",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "LocationsForAction",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ProjectMember",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "TaskInKanban",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ToDoTask",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "TopicInProject",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActivityGroup",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Activity",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "AlertType",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "LineOfProduct",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ChronogramRevision",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ChronogramText",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ProposalStatus",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "DeclarationItem",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Currency",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "FinancialLineSubType",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "FinancialLineType",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "FunctionalRole",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "LocationInKanban",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Sprint",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "TaskItem",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActionItem",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Topic",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SkillGroup",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "KanbanBoard",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Audit",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "TaskTypes",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActionGroup",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ActionPlanRevision",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "ProjectItem",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "CertificationLine",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Proposal",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "Commission",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "UserInTeam",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "OrganizationalRole",
                schema: "PDC");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "PDC");
        }
    }
}
