using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UpdateDbSetsCertification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInLocation_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInLocation_Locations_LocationId",
                schema: "PDC",
                table: "CertificationInLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationInLocation",
                schema: "PDC",
                table: "CertificationInLocation");

            migrationBuilder.RenameTable(
                name: "CertificationInLocation",
                schema: "PDC",
                newName: "CertificationInLocations",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationInLocation_LocationId",
                schema: "PDC",
                table: "CertificationInLocations",
                newName: "IX_CertificationInLocations_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationInLocations",
                schema: "PDC",
                table: "CertificationInLocations",
                columns: new[] { "CertificationLineId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInLocations_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInLocations",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInLocations_Locations_LocationId",
                schema: "PDC",
                table: "CertificationInLocations",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInLocations_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificationInLocations_Locations_LocationId",
                schema: "PDC",
                table: "CertificationInLocations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationInLocations",
                schema: "PDC",
                table: "CertificationInLocations");

            migrationBuilder.RenameTable(
                name: "CertificationInLocations",
                schema: "PDC",
                newName: "CertificationInLocation",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_CertificationInLocations_LocationId",
                schema: "PDC",
                table: "CertificationInLocation",
                newName: "IX_CertificationInLocation_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationInLocation",
                schema: "PDC",
                table: "CertificationInLocation",
                columns: new[] { "CertificationLineId", "LocationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInLocation_CertificationLines_CertificationLineId",
                schema: "PDC",
                table: "CertificationInLocation",
                column: "CertificationLineId",
                principalSchema: "PDC",
                principalTable: "CertificationLines",
                principalColumn: "CertificationLineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificationInLocation_Locations_LocationId",
                schema: "PDC",
                table: "CertificationInLocation",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
