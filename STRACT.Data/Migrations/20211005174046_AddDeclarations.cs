using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class AddDeclarations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_OrganizationalRole_OrganizationalRoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "PDCUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrganizationalRoleId",
                table: "PDCUsers",
                newName: "IX_PDCUsers_OrganizationalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PDCUsers",
                table: "PDCUsers",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Motive = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.DeclarationId);
                    table.ForeignKey(
                        name: "FK_Declarations_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationRevision",
                columns: table => new
                {
                    DeclarationRevisionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RevisionDescription = table.Column<string>(type: "TEXT", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    DeclarationItemId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationRevision", x => x.DeclarationRevisionId);
                    table.ForeignKey(
                        name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
                        column: x => x.DeclarationItemId,
                        principalTable: "Declarations",
                        principalColumn: "DeclarationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationRevision_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationSignatures",
                columns: table => new
                {
                    SignatureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateSigned = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeclarationId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationSignatures", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_DeclarationSignatures_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalTable: "Declarations",
                        principalColumn: "DeclarationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeclarationSignatures_PDCUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "PDCUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_DeclarationItemId",
                table: "DeclarationRevision",
                column: "DeclarationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationRevision_UserId",
                table: "DeclarationRevision",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_UserId",
                table: "Declarations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignatures_DeclarationId",
                table: "DeclarationSignatures",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationSignatures_UserId",
                table: "DeclarationSignatures",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PDCUsers_OrganizationalRole_OrganizationalRoleId",
                table: "PDCUsers",
                column: "OrganizationalRoleId",
                principalTable: "OrganizationalRole",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PDCUsers_OrganizationalRole_OrganizationalRoleId",
                table: "PDCUsers");

            migrationBuilder.DropTable(
                name: "DeclarationRevision");

            migrationBuilder.DropTable(
                name: "DeclarationSignatures");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PDCUsers",
                table: "PDCUsers");

            migrationBuilder.RenameTable(
                name: "PDCUsers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_PDCUsers_OrganizationalRoleId",
                table: "Users",
                newName: "IX_Users_OrganizationalRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_OrganizationalRole_OrganizationalRoleId",
                table: "Users",
                column: "OrganizationalRoleId",
                principalTable: "OrganizationalRole",
                principalColumn: "OrganizationalRoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
