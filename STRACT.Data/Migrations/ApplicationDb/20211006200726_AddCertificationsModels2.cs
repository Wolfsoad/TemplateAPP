using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.ApplicationDb
{
    public partial class AddCertificationsModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                schema: "Identity",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityGroups",
                schema: "Identity",
                columns: table => new
                {
                    ActivityGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityGroups", x => x.ActivityGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Commission",
                schema: "Identity",
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
                name: "Entity",
                schema: "Identity",
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
                name: "FunctionalRole",
                schema: "Identity",
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
                schema: "Identity",
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
                schema: "Identity",
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
                name: "OrganizationalRole",
                schema: "Identity",
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
                name: "ProposalStatus",
                schema: "Identity",
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
                name: "SkillGroup",
                schema: "Identity",
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
                name: "ActivityInGroups",
                schema: "Identity",
                columns: table => new
                {
                    ActivityGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    ActivityGroupId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInGroups", x => x.ActivityGroupId);
                    table.ForeignKey(
                        name: "FK_ActivityInGroups_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalSchema: "Identity",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInGroups_ActivityGroups_ActivityGroupId1",
                        column: x => x.ActivityGroupId1,
                        principalSchema: "Identity",
                        principalTable: "ActivityGroups",
                        principalColumn: "ActivityGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionForProjects",
                schema: "Identity",
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
                    table.PrimaryKey("PK_CommissionForProjects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_CommissionForProjects_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalSchema: "Identity",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationLine",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPerson",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityFunctionalRole",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityFunctionalRole_FunctionalRole_FunctionalRolesFunctionalRoleId",
                        column: x => x.FunctionalRolesFunctionalRoleId,
                        principalSchema: "Identity",
                        principalTable: "FunctionalRole",
                        principalColumn: "FunctionalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityOrganizationalRole",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityOrganizationalRole_OrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                        column: x => x.OrganizationalRolesOrganizationalRoleId,
                        principalSchema: "Identity",
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PDCUsers",
                schema: "Identity",
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
                    table.PrimaryKey("PK_PDCUsers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_PDCUsers_OrganizationalRole_OrganizationalRoleId",
                        column: x => x.OrganizationalRoleId,
                        principalSchema: "Identity",
                        principalTable: "OrganizationalRole",
                        principalColumn: "OrganizationalRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PDCUsers_User_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Decision",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decision_ProposalStatus_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Identity",
                        principalTable: "ProposalStatus",
                        principalColumn: "ProposalStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "SkillGroup",
                        principalColumn: "SkillGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "Identity",
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Declarations",
                schema: "Identity",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.DeclarationId);
                    table.ForeignKey(
                        name: "FK_Declarations_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                schema: "Identity",
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
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Proposal_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalSchema: "Identity",
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposal_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySkill",
                schema: "Identity",
                columns: table => new
                {
                    ActivitiesActivityId = table.Column<int>(type: "int", nullable: false),
                    SkillsSkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySkill", x => new { x.ActivitiesActivityId, x.SkillsSkillId });
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Activities_ActivitiesActivityId",
                        column: x => x.ActivitiesActivityId,
                        principalSchema: "Identity",
                        principalTable: "Activities",
                        principalColumn: "ActivityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivitySkill_Skill_SkillsSkillId",
                        column: x => x.SkillsSkillId,
                        principalSchema: "Identity",
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProductLines",
                schema: "Identity",
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
                        principalSchema: "Identity",
                        principalTable: "Certificate",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateProductLines_LineOfProduct_LineOfProductId",
                        column: x => x.LineOfProductId,
                        principalSchema: "Identity",
                        principalTable: "LineOfProduct",
                        principalColumn: "LineOfProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationRevision",
                schema: "Identity",
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
                        name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalSchema: "Identity",
                        principalTable: "Declarations",
                        principalColumn: "DeclarationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationRevision_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationSignatures",
                schema: "Identity",
                columns: table => new
                {
                    SignatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclarationId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationSignatures", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_DeclarationSignatures_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalSchema: "Identity",
                        principalTable: "Declarations",
                        principalColumn: "DeclarationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationSignatures_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFunctionalRole_FunctionalRolesFunctionalRoleId",
                schema: "Identity",
                table: "ActivityFunctionalRole",
                column: "FunctionalRolesFunctionalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroups_ActivityGroupId1",
                schema: "Identity",
                table: "ActivityInGroups",
                column: "ActivityGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInGroups_ActivityId",
                schema: "Identity",
                table: "ActivityInGroups",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityOrganizationalRole_OrganizationalRolesOrganizationalRoleId",
                schema: "Identity",
                table: "ActivityOrganizationalRole",
                column: "OrganizationalRolesOrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitySkill_SkillsSkillId",
                schema: "Identity",
                table: "ActivitySkill",
                column: "SkillsSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CertificationLineId",
                schema: "Identity",
                table: "Audit",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LocationId",
                schema: "Identity",
                table: "Audit",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_UserId",
                schema: "Identity",
                table: "Audit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CertificationLineId",
                schema: "Identity",
                table: "Certificate",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_CertificateId",
                schema: "Identity",
                table: "CertificateProductLines",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_LineOfProductId",
                schema: "Identity",
                table: "CertificateProductLines",
                column: "LineOfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationLine_EntityId",
                schema: "Identity",
                table: "CertificationLine",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionForProjects_CommissionId",
                schema: "Identity",
                table: "CommissionForProjects",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPerson_EntityId",
                schema: "Identity",
                table: "ContactPerson",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_CommissionId",
                schema: "Identity",
                table: "Decision",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_StatusId",
                schema: "Identity",
                table: "Decision",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_DeclarationItemId",
                schema: "Identity",
                table: "DeclarationRevision",
                column: "DeclarationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_UserId",
                schema: "Identity",
                table: "DeclarationRevision",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_UserId",
                schema: "Identity",
                table: "Declarations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignatures_DeclarationId",
                schema: "Identity",
                table: "DeclarationSignatures",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignatures_UserId",
                schema: "Identity",
                table: "DeclarationSignatures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PDCUsers_ApplicationUserId1",
                schema: "Identity",
                table: "PDCUsers",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_PDCUsers_OrganizationalRoleId",
                schema: "Identity",
                table: "PDCUsers",
                column: "OrganizationalRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_CommissionId",
                schema: "Identity",
                table: "Proposal",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_UserId",
                schema: "Identity",
                table: "Proposal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_SkillGroupId",
                schema: "Identity",
                table: "Skill",
                column: "SkillGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityFunctionalRole",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActivityInGroups",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActivityOrganizationalRole",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActivitySkill",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Audit",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CertificateProductLines",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CommissionForProjects",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ContactPerson",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Decision",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DeclarationRevision",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DeclarationSignatures",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Proposal",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FunctionalRole",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ActivityGroups",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Activities",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Skill",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Certificate",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "LineOfProduct",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "ProposalStatus",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Declarations",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Commission",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SkillGroup",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CertificationLine",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PDCUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "OrganizationalRole",
                schema: "Identity");
        }
    }
}
