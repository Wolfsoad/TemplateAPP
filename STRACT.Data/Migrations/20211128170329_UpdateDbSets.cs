using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UpdateDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audit_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.DropForeignKey(
                name: "FK_Audit_Locations_LocationId",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.DropForeignKey(
                name: "FK_Audit_UserInTeam_UserId",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInActionItems_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "CertificationInActionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLine_Entity_EntityId",
                schema: "PDC",
                table: "CertificationLine");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPerson_Entity_EntityId",
                schema: "PDC",
                table: "ContactPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Audit_AuditId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                schema: "PDC",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPerson",
                schema: "PDC",
                table: "ContactPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLine",
                schema: "PDC",
                table: "CertificationLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audit",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.RenameTable(
                name: "Entity",
                schema: "PDC",
                newName: "Entities",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                schema: "PDC",
                newName: "ContactPeople",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CertificationLine",
                schema: "PDC",
                newName: "CertificationLines",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Audit",
                schema: "PDC",
                newName: "Audits",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPerson_EntityId",
                schema: "PDC",
                table: "ContactPeople",
                newName: "IX_ContactPeople_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationLine_EntityId",
                schema: "PDC",
                table: "CertificationLines",
                newName: "IX_CertificationLines_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_UserId",
                schema: "PDC",
                table: "Audits",
                newName: "IX_Audits_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_LocationId",
                schema: "PDC",
                table: "Audits",
                newName: "IX_Audits_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Audit_CertificationLineId",
                schema: "PDC",
                table: "Audits",
                newName: "IX_Audits_CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entities",
                schema: "PDC",
                table: "Entities",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPeople",
                schema: "PDC",
                table: "ContactPeople",
                column: "ContactPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLines",
                schema: "PDC",
                table: "CertificationLines",
                column: "CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audits",
                schema: "PDC",
                table: "Audits",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Audits",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_Locations_LocationId",
                schema: "PDC",
                table: "Audits",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_UserInTeam_UserId",
                schema: "PDC",
                table: "Audits",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Certificate",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInActionItems_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInActionItems",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLines_Entities_EntityId",
                schema: "PDC",
                table: "CertificationLines",
                column: "EntityId",
                principalSchema: "PDC",
                principalTable: "Entities",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPeople_Entities_EntityId",
                schema: "PDC",
                table: "ContactPeople",
                column: "EntityId",
                principalSchema: "PDC",
                principalTable: "Entities",
                principalColumn: "EntityId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audits_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Audits");

            migrationBuilder.DropForeignKey(
                name: "FK_Audits_Locations_LocationId",
                schema: "PDC",
                table: "Audits");

            migrationBuilder.DropForeignKey(
                name: "FK_Audits_UserInTeam_UserId",
                schema: "PDC",
                table: "Audits");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInActionItems_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInActionItems");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationLines_Entities_EntityId",
                schema: "PDC",
                table: "CertificationLines");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactPeople_Entities_EntityId",
                schema: "PDC",
                table: "ContactPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItem_Audits_AuditId",
                schema: "PDC",
                table: "TaskItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entities",
                schema: "PDC",
                table: "Entities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactPeople",
                schema: "PDC",
                table: "ContactPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationLines",
                schema: "PDC",
                table: "CertificationLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Audits",
                schema: "PDC",
                table: "Audits");

            migrationBuilder.RenameTable(
                name: "Entities",
                schema: "PDC",
                newName: "Entity",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ContactPeople",
                schema: "PDC",
                newName: "ContactPerson",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CertificationLines",
                schema: "PDC",
                newName: "CertificationLine",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Audits",
                schema: "PDC",
                newName: "Audit",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_ContactPeople_EntityId",
                schema: "PDC",
                table: "ContactPerson",
                newName: "IX_ContactPerson_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationLines_EntityId",
                schema: "PDC",
                table: "CertificationLine",
                newName: "IX_CertificationLine_EntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Audits_UserId",
                schema: "PDC",
                table: "Audit",
                newName: "IX_Audit_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Audits_LocationId",
                schema: "PDC",
                table: "Audit",
                newName: "IX_Audit_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Audits_CertificationLineId",
                schema: "PDC",
                table: "Audit",
                newName: "IX_Audit_CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                schema: "PDC",
                table: "Entity",
                column: "EntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactPerson",
                schema: "PDC",
                table: "ContactPerson",
                column: "ContactPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationLine",
                schema: "PDC",
                table: "CertificationLine",
                column: "CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Audit",
                schema: "PDC",
                table: "Audit",
                column: "AuditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "Audit",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLine",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Locations_LocationId",
                schema: "PDC",
                table: "Audit",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_UserInTeam_UserId",
                schema: "PDC",
                table: "Audit",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificate_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "Certificate",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLine",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInActionItems_CertificationLine_CertificationLineId",
                schema: "PDC",
                table: "CertificationInActionItems",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLine",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationLine_Entity_EntityId",
                schema: "PDC",
                table: "CertificationLine",
                column: "EntityId",
                principalSchema: "PDC",
                principalTable: "Entity",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPerson_Entity_EntityId",
                schema: "PDC",
                table: "ContactPerson",
                column: "EntityId",
                principalSchema: "PDC",
                principalTable: "Entity",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItem_Audit_AuditId",
                schema: "PDC",
                table: "TaskItem",
                column: "AuditId",
                principalSchema: "PDC",
                principalTable: "Audit",
                principalColumn: "AuditId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
