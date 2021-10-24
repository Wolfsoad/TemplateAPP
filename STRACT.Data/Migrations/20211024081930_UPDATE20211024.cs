using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations
{
    public partial class UPDATE20211024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionGroup_ActionGroupId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItemLineOfProduct_LineOfProduct_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroup_ActivityGroup_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup");

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
                name: "FK_DeclarationItem_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationItem");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationRevision_DeclarationItem_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationSignature_DeclarationItem_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignature");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Currency_CurrencyId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineSubType_FinancialLineSubtypeId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineType_FinancialLineTypeId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Location_LocationId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationsForAction_Location_LocationId1",
                schema: "PDC",
                table: "LocationsForAction");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "ToDoTask");

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
                name: "PK_FinancialLineType",
                schema: "PDC",
                table: "FinancialLineType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineSubType",
                schema: "PDC",
                table: "FinancialLineSubType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeclarationItem",
                schema: "PDC",
                table: "DeclarationItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currency",
                schema: "PDC",
                table: "Currency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertType",
                schema: "PDC",
                table: "AlertType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityGroup",
                schema: "PDC",
                table: "ActivityGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionGroup",
                schema: "PDC",
                table: "ActionGroup");

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
                name: "FinancialLineType",
                schema: "PDC",
                newName: "FinancialLineTypes",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubType",
                schema: "PDC",
                newName: "FinancialLineSubTypes",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationItem",
                schema: "PDC",
                newName: "Declarations",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Currency",
                schema: "PDC",
                newName: "Currencies",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AlertType",
                schema: "PDC",
                newName: "AlertTypes",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityGroup",
                schema: "PDC",
                newName: "ActivityGroups",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionGroup",
                schema: "PDC",
                newName: "ActionGroups",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_DeclarationItem_UserId",
                schema: "PDC",
                table: "Declarations",
                newName: "IX_Declarations_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserInTeamId",
                schema: "PDC",
                table: "ToDoTask",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "PK_FinancialLineTypes",
                schema: "PDC",
                table: "FinancialLineTypes",
                column: "FinancialLineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineSubTypes",
                schema: "PDC",
                table: "FinancialLineSubTypes",
                column: "FinancialLineSubTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declarations",
                schema: "PDC",
                table: "Declarations",
                column: "DeclarationItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currencies",
                schema: "PDC",
                table: "Currencies",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertTypes",
                schema: "PDC",
                table: "AlertTypes",
                column: "AlertTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityGroups",
                schema: "PDC",
                table: "ActivityGroups",
                column: "ActivityGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionGroups",
                schema: "PDC",
                table: "ActionGroups",
                column: "ActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionItem_DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionGroups_ActionGroupId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionGroupId",
                principalSchema: "PDC",
                principalTable: "ActionGroups",
                principalColumn: "ActionGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionPlanRevisionId",
                principalSchema: "PDC",
                principalTable: "ActionPlanRevision",
                principalColumn: "ActionPlanRevisionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_Department_DepartmentId",
                schema: "PDC",
                table: "ActionItem",
                column: "DepartmentId",
                principalSchema: "PDC",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ActivityInGroup_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityGroupId",
                principalSchema: "PDC",
                principalTable: "ActivityGroups",
                principalColumn: "ActivityGroupId",
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
                name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "Declarations",
                principalColumn: "DeclarationItemId",
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
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Currencies_CurrencyId",
                schema: "PDC",
                table: "FinancialLine",
                column: "CurrencyId",
                principalSchema: "PDC",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineSubTypes_FinancialLineSubtypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineSubtypeId",
                principalSchema: "PDC",
                principalTable: "FinancialLineSubTypes",
                principalColumn: "FinancialLineSubTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineTypes_FinancialLineTypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineTypeId",
                principalSchema: "PDC",
                principalTable: "FinancialLineTypes",
                principalColumn: "FinancialLineTypeId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ToDoTask_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "ToDoTask",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_ActionItem_ActionGroups_ActionGroupId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_Department_DepartmentId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionItemLineOfProduct_LinesOfProducts_LinesOfProductsLineOfProductId",
                schema: "PDC",
                table: "ActionItemLineOfProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInGroup_ActivityGroups_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup");

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
                name: "FK_DeclarationRevision_Declarations_DeclarationItemId",
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
                name: "FK_FinancialLine_Currencies_CurrencyId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineSubTypes_FinancialLineSubtypeId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_FinancialLineTypes_FinancialLineTypeId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialLine_Locations_LocationId",
                schema: "PDC",
                table: "FinancialLine");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationsForAction_Locations_LocationId1",
                schema: "PDC",
                table: "LocationsForAction");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoTask_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "ToDoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TopicInProject_Topics_TopicId",
                schema: "PDC",
                table: "TopicInProject");

            migrationBuilder.DropIndex(
                name: "IX_ActionItem_DepartmentId",
                schema: "PDC",
                table: "ActionItem");

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
                name: "PK_FinancialLineTypes",
                schema: "PDC",
                table: "FinancialLineTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinancialLineSubTypes",
                schema: "PDC",
                table: "FinancialLineSubTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declarations",
                schema: "PDC",
                table: "Declarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Currencies",
                schema: "PDC",
                table: "Currencies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertTypes",
                schema: "PDC",
                table: "AlertTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityGroups",
                schema: "PDC",
                table: "ActivityGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActionGroups",
                schema: "PDC",
                table: "ActionGroups");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                schema: "PDC",
                table: "ActionItem");

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
                name: "FinancialLineTypes",
                schema: "PDC",
                newName: "FinancialLineType",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubTypes",
                schema: "PDC",
                newName: "FinancialLineSubType",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Declarations",
                schema: "PDC",
                newName: "DeclarationItem",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Currencies",
                schema: "PDC",
                newName: "Currency",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AlertTypes",
                schema: "PDC",
                newName: "AlertType",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityGroups",
                schema: "PDC",
                newName: "ActivityGroup",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionGroups",
                schema: "PDC",
                newName: "ActionGroup",
                newSchema: "PDC");

            migrationBuilder.RenameIndex(
                name: "IX_Declarations_UserId",
                schema: "PDC",
                table: "DeclarationItem",
                newName: "IX_DeclarationItem_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserInTeamId",
                schema: "PDC",
                table: "ToDoTask",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "PK_FinancialLineType",
                schema: "PDC",
                table: "FinancialLineType",
                column: "FinancialLineTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinancialLineSubType",
                schema: "PDC",
                table: "FinancialLineSubType",
                column: "FinancialLineSubTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeclarationItem",
                schema: "PDC",
                table: "DeclarationItem",
                column: "DeclarationItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Currency",
                schema: "PDC",
                table: "Currency",
                column: "CurrencyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertType",
                schema: "PDC",
                table: "AlertType",
                column: "AlertTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityGroup",
                schema: "PDC",
                table: "ActivityGroup",
                column: "ActivityGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActionGroup",
                schema: "PDC",
                table: "ActionGroup",
                column: "ActionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionGroup_ActionGroupId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionGroupId",
                principalSchema: "PDC",
                principalTable: "ActionGroup",
                principalColumn: "ActionGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ActionPlanRevision_ActionPlanRevisionId",
                schema: "PDC",
                table: "ActionItem",
                column: "ActionPlanRevisionId",
                principalSchema: "PDC",
                principalTable: "ActionPlanRevision",
                principalColumn: "ActionPlanRevisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItem_ProjectItem_ProjectItemId",
                schema: "PDC",
                table: "ActionItem",
                column: "ProjectItemId",
                principalSchema: "PDC",
                principalTable: "ProjectItem",
                principalColumn: "ProjectItemId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ActivityInGroup_ActivityGroup_ActivityGroupId",
                schema: "PDC",
                table: "ActivityInGroup",
                column: "ActivityGroupId",
                principalSchema: "PDC",
                principalTable: "ActivityGroup",
                principalColumn: "ActivityGroupId",
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
                name: "FK_DeclarationItem_UserInTeam_UserId",
                schema: "PDC",
                table: "DeclarationItem",
                column: "UserId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationRevision_DeclarationItem_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationRevision",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "DeclarationItem",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationSignature_DeclarationItem_DeclarationItemId",
                schema: "PDC",
                table: "DeclarationSignature",
                column: "DeclarationItemId",
                principalSchema: "PDC",
                principalTable: "DeclarationItem",
                principalColumn: "DeclarationItemId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_Currency_CurrencyId",
                schema: "PDC",
                table: "FinancialLine",
                column: "CurrencyId",
                principalSchema: "PDC",
                principalTable: "Currency",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineSubType_FinancialLineSubtypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineSubtypeId",
                principalSchema: "PDC",
                principalTable: "FinancialLineSubType",
                principalColumn: "FinancialLineSubTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialLine_FinancialLineType_FinancialLineTypeId",
                schema: "PDC",
                table: "FinancialLine",
                column: "FinancialLineTypeId",
                principalSchema: "PDC",
                principalTable: "FinancialLineType",
                principalColumn: "FinancialLineTypeId",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_ToDoTask_UserInTeam_UserInTeamId",
                schema: "PDC",
                table: "ToDoTask",
                column: "UserInTeamId",
                principalSchema: "PDC",
                principalTable: "UserInTeam",
                principalColumn: "UserInTeamId",
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
