using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.PDC
{
    public partial class UPDATE20211019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItemLineOfProduct_LineOfProduct_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertInProject_AlertType_AlertTypeId",
                schema: "PDC",
                table: "AlertInProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Audit_Location_LocationId",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateProductLines_LineOfProduct_LineOfProductId",
                schema: "PDC",
                table: "CertificateProductLines");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Location_LocationId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationsForAction_Location_LocationId1",
                schema: "PDC",
                table: "LocationsForAction");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInProject_Topic_TopicId",
                schema: "PDC",
                table: "TopicInProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topic",
                schema: "PDC",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                schema: "PDC",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LineOfProduct",
                schema: "PDC",
                table: "LineOfProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertType",
                schema: "PDC",
                table: "AlertType");

            migrationBuilder.RenameTable(
                name: "Topic",
                schema: "PDC",
                newName: "Topics",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Location",
                schema: "PDC",
                newName: "Locations",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "LineOfProduct",
                schema: "PDC",
                newName: "LinesOfProducts",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AlertType",
                schema: "PDC",
                newName: "AlertTypes",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topics",
                schema: "PDC",
                table: "Topics",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                schema: "PDC",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinesOfProducts",
                schema: "PDC",
                table: "LinesOfProducts",
                column: "LineOfProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertTypes",
                schema: "PDC",
                table: "AlertTypes",
                column: "AlertTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItemLineOfProduct_LinesOfProducts_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct",
                column: "LinesOfProductsLineOfProductId",
                principalSchema: "PDC",
                principalTable: "LinesOfProducts",
                principalColumn: "LineOfProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertInProject_AlertTypes_AlertTypeId",
                schema: "PDC",
                table: "AlertInProject",
                column: "AlertTypeId",
                principalSchema: "PDC",
                principalTable: "AlertTypes",
                principalColumn: "AlertTypeId",
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
                name: "FK_CertificateProductLines_LinesOfProducts_LineOfProductId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "LineOfProductId",
                principalSchema: "PDC",
                principalTable: "LinesOfProducts",
                principalColumn: "LineOfProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Locations_LocationId",
                schema: "PDC",
                table: "FinancialLine",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationsForAction_Locations_LocationId1",
                schema: "PDC",
                table: "LocationsForAction",
                column: "LocationId1",
                principalSchema: "PDC",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInProject_Topics_TopicId",
                schema: "PDC",
                table: "TopicInProject",
                column: "TopicId",
                principalSchema: "PDC",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItemLineOfProduct_LinesOfProducts_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertInProject_AlertTypes_AlertTypeId",
                schema: "PDC",
                table: "AlertInProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Audit_Locations_LocationId",
                schema: "PDC",
                table: "Audit");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateProductLines_LinesOfProducts_LineOfProductId",
                schema: "PDC",
                table: "CertificateProductLines");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Locations_LocationId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationsForAction_Locations_LocationId1",
                schema: "PDC",
                table: "LocationsForAction");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInProject_Topics_TopicId",
                schema: "PDC",
                table: "TopicInProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topics",
                schema: "PDC",
                table: "Topics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                schema: "PDC",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinesOfProducts",
                schema: "PDC",
                table: "LinesOfProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertTypes",
                schema: "PDC",
                table: "AlertTypes");

            migrationBuilder.RenameTable(
                name: "Topics",
                schema: "PDC",
                newName: "Topic",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "PDC",
                newName: "Location",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "LinesOfProducts",
                schema: "PDC",
                newName: "LineOfProduct",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AlertTypes",
                schema: "PDC",
                newName: "AlertType",
                newSchema: "PDC");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topic",
                schema: "PDC",
                table: "Topic",
                column: "TopicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                schema: "PDC",
                table: "Location",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LineOfProduct",
                schema: "PDC",
                table: "LineOfProduct",
                column: "LineOfProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertType",
                schema: "PDC",
                table: "AlertType",
                column: "AlertTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItemLineOfProduct_LineOfProduct_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct",
                column: "LinesOfProductsLineOfProductId",
                principalSchema: "PDC",
                principalTable: "LineOfProduct",
                principalColumn: "LineOfProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertInProject_AlertType_AlertTypeId",
                schema: "PDC",
                table: "AlertInProject",
                column: "AlertTypeId",
                principalSchema: "PDC",
                principalTable: "AlertType",
                principalColumn: "AlertTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Audit_Location_LocationId",
                schema: "PDC",
                table: "Audit",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateProductLines_LineOfProduct_LineOfProductId",
                schema: "PDC",
                table: "CertificateProductLines",
                column: "LineOfProductId",
                principalSchema: "PDC",
                principalTable: "LineOfProduct",
                principalColumn: "LineOfProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Location_LocationId",
                schema: "PDC",
                table: "FinancialLine",
                column: "LocationId",
                principalSchema: "PDC",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationsForAction_Location_LocationId1",
                schema: "PDC",
                table: "LocationsForAction",
                column: "LocationId1",
                principalSchema: "PDC",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TopicInProject_Topic_TopicId",
                schema: "PDC",
                table: "TopicInProject",
                column: "TopicId",
                principalSchema: "PDC",
                principalTable: "Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
