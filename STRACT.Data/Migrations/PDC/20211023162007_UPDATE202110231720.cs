using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.PDC
{
    public partial class UPDATE202110231720 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Currency_CurrencyId",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineSubType_FinancialLineSubtypeId",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineType_FinancialLineTypeId",
                table: "FinancialLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineType",
                table: "FinancialLineType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineSubType",
                table: "FinancialLineSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                table: "Currency");

            migrationBuilder.RenameTable(
                name: "FinancialLineType",
                newName: "FinancialLineTypes");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubType",
                newName: "FinancialLineSubTypes");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currencies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineTypes",
                table: "FinancialLineTypes",
                column: "FinancialLineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineSubTypes",
                table: "FinancialLineSubTypes",
                column: "FinancialLineSubTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Currencies_CurrencyId",
                table: "FinancialLine",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineSubTypes_FinancialLineSubtypeId",
                table: "FinancialLine",
                column: "FinancialLineSubtypeId",
                principalTable: "FinancialLineSubTypes",
                principalColumn: "FinancialLineSubTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineTypes_FinancialLineTypeId",
                table: "FinancialLine",
                column: "FinancialLineTypeId",
                principalTable: "FinancialLineTypes",
                principalColumn: "FinancialLineTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Currencies_CurrencyId",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineSubTypes_FinancialLineSubtypeId",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineTypes_FinancialLineTypeId",
                table: "FinancialLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineTypes",
                table: "FinancialLineTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineSubTypes",
                table: "FinancialLineSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                table: "Currencies");

            migrationBuilder.RenameTable(
                name: "FinancialLineTypes",
                newName: "FinancialLineType");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubTypes",
                newName: "FinancialLineSubType");

            migrationBuilder.RenameTable(
                name: "Currencies",
                newName: "Currency");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineType",
                table: "FinancialLineType",
                column: "FinancialLineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineSubType",
                table: "FinancialLineSubType",
                column: "FinancialLineSubTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Currency_CurrencyId",
                table: "FinancialLine",
                column: "CurrencyId",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineSubType_FinancialLineSubtypeId",
                table: "FinancialLine",
                column: "FinancialLineSubtypeId",
                principalTable: "FinancialLineSubType",
                principalColumn: "FinancialLineSubTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineType_FinancialLineTypeId",
                table: "FinancialLine",
                column: "FinancialLineTypeId",
                principalTable: "FinancialLineType",
                principalColumn: "FinancialLineTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
