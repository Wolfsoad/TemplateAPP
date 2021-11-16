using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class Update202201222141 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Hours",
                schema: "PDC",
                table: "TaskItems",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Hours",
                schema: "PDC",
                table: "TaskItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
