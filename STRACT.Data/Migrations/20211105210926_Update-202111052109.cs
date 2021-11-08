using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update202111052109 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationRevision_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_Declarations_UserInTeam_UserId",
                schema: "PDC",
                table: "Declarations");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationSignature_Declarations_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignature");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationSignature_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationSignature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationSignature",
                schema: "PDC",
                table: "DeclarationSignature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declarations",
                schema: "PDC",
                table: "Declarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationRevision",
                schema: "PDC",
                table: "DeclarationRevision");

            migrationBuilder.RenameTable(
                name: "DeclarationSignature",
                schema: "PDC",
                newName: "DeclarationSignatures",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Declarations",
                schema: "PDC",
                newName: "DeclarationItems",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationRevision",
                schema: "PDC",
                newName: "DeclarationRevisions",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationSignature_UserId",
                schema: "PDC",
                table: "DeclarationSignatures",
                newName: "IX_DeclarationSignatures_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Declarations_UserId",
                schema: "PDC",
                table: "DeclarationItems",
                newName: "IX_DeclarationItems_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationRevision_UserId",
                schema: "PDC",
                table: "DeclarationRevisions",
                newName: "IX_DeclarationRevisions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationRevision_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevisions",
                newName: "IX_DeclarationRevisions_DeclarationItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationSignatures",
                schema: "PDC",
                table: "DeclarationSignatures",
                columns: new[] { "DeclarationItemId", "SignatureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationItems",
                schema: "PDC",
                table: "DeclarationItems",
                column: "DeclarationItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationRevisions",
                schema: "PDC",
                table: "DeclarationRevisions",
                column: "DeclarationRevisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationItems_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationItems",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationRevisions_DeclarationItems_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevisions",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "DeclarationItems",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationRevisions_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationRevisions",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationSignatures_DeclarationItems_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignatures",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "DeclarationItems",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationSignatures_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationSignatures",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationItems_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationRevisions_DeclarationItems_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevisions");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationRevisions_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationRevisions");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationSignatures_DeclarationItems_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignatures");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationSignatures_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationSignatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationSignatures",
                schema: "PDC",
                table: "DeclarationSignatures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationRevisions",
                schema: "PDC",
                table: "DeclarationRevisions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationItems",
                schema: "PDC",
                table: "DeclarationItems");

            migrationBuilder.RenameTable(
                name: "DeclarationSignatures",
                schema: "PDC",
                newName: "DeclarationSignature",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationRevisions",
                schema: "PDC",
                newName: "DeclarationRevision",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationItems",
                schema: "PDC",
                newName: "Declarations",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationSignatures_UserId",
                schema: "PDC",
                table: "DeclarationSignature",
                newName: "IX_DeclarationSignature_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationRevisions_UserId",
                schema: "PDC",
                table: "DeclarationRevision",
                newName: "IX_DeclarationRevision_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationRevisions_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision",
                newName: "IX_DeclarationRevision_DeclarationItemId");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationItems_UserId",
                schema: "PDC",
                table: "Declarations",
                newName: "IX_Declarations_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationSignature",
                schema: "PDC",
                table: "DeclarationSignature",
                columns: new[] { "DeclarationItemId", "SignatureId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationRevision",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "DeclarationRevisionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declarations",
                schema: "PDC",
                table: "Declarations",
                column: "DeclarationItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "Declarations",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationRevision_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Declarations_UserInTeam_UserId",
                schema: "PDC",
                table: "Declarations",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationSignature_Declarations_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignature",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "Declarations",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationSignature_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationSignature",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
