using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Correction20211204 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                schema: "PDC",
                table: "CertificationLines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                schema: "PDC",
                table: "CertificationLines");
        }
    }
}
