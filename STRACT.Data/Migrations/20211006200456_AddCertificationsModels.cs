using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class AddCertificationsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commission",
                columns: table => new
                {
                    CommissionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.CommissionId);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    SupplierCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "LineOfProduct",
                columns: table => new
                {
                    LineOfProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineOfProduct", x => x.LineOfProductId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    PostCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "ProposalStatus",
                columns: table => new
                {
                    ProposalStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProposalStatus", x => x.ProposalStatusId);
                });

            migrationBuilder.CreateTable(
                name: "CommissionForProjects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Proposal = table.Column<string>(type: "TEXT", nullable: true),
                    SupportDocuments = table.Column<string>(type: "TEXT", nullable: true),
                    Justification = table.Column<string>(type: "TEXT", nullable: true),
                    Advantages = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionForProjects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_CommissionForProjects_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proposal",
                columns: table => new
                {
                    ProposalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateSent = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: true),
                    CommissionId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposal", x => x.ProposalId);
                    table.ForeignKey(
                        name: "FK_Proposal_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proposal_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificationLine",
                columns: table => new
                {
                    CertificationLineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    FactoryAudit = table.Column<bool>(type: "INTEGER", nullable: false),
                    FolderPath = table.Column<string>(type: "TEXT", nullable: true),
                    AuditFrequency = table.Column<int>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationLine", x => x.CertificationLineId);
                    table.ForeignKey(
                        name: "FK_CertificationLine_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactPerson",
                columns: table => new
                {
                    ContactPersonId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    IsMainContact = table.Column<bool>(type: "INTEGER", nullable: false),
                    EntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPerson", x => x.ContactPersonId);
                    table.ForeignKey(
                        name: "FK_ContactPerson_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decision",
                columns: table => new
                {
                    DecisionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Subject = table.Column<string>(type: "TEXT", nullable: true),
                    Minutes = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfDecision = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommissionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decision", x => x.DecisionId);
                    table.ForeignKey(
                        name: "FK_Decision_Commission_CommissionId",
                        column: x => x.CommissionId,
                        principalTable: "Commission",
                        principalColumn: "CommissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Decision_ProposalStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ProposalStatus",
                        principalColumn: "ProposalStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audit",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    DateOfAudit = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concluded = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CertificationLineId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audit", x => x.AuditId);
                    table.ForeignKey(
                        name: "FK_Audit_CertificationLine_CertificationLineId",
                        column: x => x.CertificationLineId,
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Audit_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    CertificateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    EmissionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CertificateUrl = table.Column<string>(type: "TEXT", nullable: true),
                    CertificationLineId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.CertificateId);
                    table.ForeignKey(
                        name: "FK_Certificate_CertificationLine_CertificationLineId",
                        column: x => x.CertificationLineId,
                        principalTable: "CertificationLine",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateProductLines",
                columns: table => new
                {
                    ProductLineId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CertificateId = table.Column<int>(type: "INTEGER", nullable: false),
                    LineOfProductId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateProductLines", x => x.ProductLineId);
                    table.ForeignKey(
                        name: "FK_CertificateProductLines_Certificate_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificate",
                        principalColumn: "CertificateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificateProductLines_LineOfProduct_LineOfProductId",
                        column: x => x.LineOfProductId,
                        principalTable: "LineOfProduct",
                        principalColumn: "LineOfProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Audit_CertificationLineId",
                table: "Audit",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_LocationId",
                table: "Audit",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Audit_UserId",
                table: "Audit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_CertificationLineId",
                table: "Certificate",
                column: "CertificationLineId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_CertificateId",
                table: "CertificateProductLines",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateProductLines_LineOfProductId",
                table: "CertificateProductLines",
                column: "LineOfProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationLine_EntityId",
                table: "CertificationLine",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionForProjects_CommissionId",
                table: "CommissionForProjects",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPerson_EntityId",
                table: "ContactPerson",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_CommissionId",
                table: "Decision",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Decision_StatusId",
                table: "Decision",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_CommissionId",
                table: "Proposal",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Proposal_UserId",
                table: "Proposal",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audit");

            migrationBuilder.DropTable(
                name: "CertificateProductLines");

            migrationBuilder.DropTable(
                name: "CommissionForProjects");

            migrationBuilder.DropTable(
                name: "ContactPerson");

            migrationBuilder.DropTable(
                name: "Decision");

            migrationBuilder.DropTable(
                name: "Proposal");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "LineOfProduct");

            migrationBuilder.DropTable(
                name: "ProposalStatus");

            migrationBuilder.DropTable(
                name: "Commission");

            migrationBuilder.DropTable(
                name: "CertificationLine");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
