using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class CorrectLocationInCertification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificationInLocation",
                schema: "PDC",
                columns: table => new
                {
                    CertificationLineId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationInLocation", x => new { x.CertificationLineId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_CertificationInLocation_CertificationLines_CertificationLineId",
                        column: x => x.CertificationLineId,
                        principalSchema: "PDC",
                        principalTable: "CertificationLines",
                        principalColumn: "CertificationLineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationInLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "PDC",
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationInLocation_LocationId",
                schema: "PDC",
                table: "CertificationInLocation",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationInLocation",
                schema: "PDC");
        }
    }
}
