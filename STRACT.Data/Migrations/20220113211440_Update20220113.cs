using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update20220113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificate_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Certificate");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateProductLines_Certificate_CertificateId",
                schema: "PDC",
                table: "CertificateProductLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificate",
                schema: "PDC",
                table: "Certificate");

            migrationBuilder.RenameTable(
                name: "Certificate",
                schema: "PDC",
                newName: "Certificates",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_Certificate_CertificationLineId",
                schema: "PDC",
                table: "Certificates",
                newName: "IX_Certificates_CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificates",
                schema: "PDC",
                table: "Certificates",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateProductLines_Certificates_CertificateId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "CertificateId",
                principalSchema: "PDC",
                principalTable: "Certificates",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Certificates",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateProductLines_Certificates_CertificateId",
                schema: "PDC",
                table: "CertificateProductLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "Certificates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certificates",
                schema: "PDC",
                table: "Certificates");

            migrationBuilder.RenameTable(
                name: "Certificates",
                schema: "PDC",
                newName: "Certificate",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_Certificates_CertificationLineId",
                schema: "PDC",
                table: "Certificate",
                newName: "IX_Certificate_CertificationLineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certificate",
                schema: "PDC",
                table: "Certificate",
                column: "CertificateId");

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
                name: "FK_CertificateProductLines_Certificate_CertificateId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "CertificateId",
                principalSchema: "PDC",
                principalTable: "Certificate",
                principalColumn: "CertificateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
