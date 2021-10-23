using Microsoft.EntityFrameworkCore.Migrations;

namespace STRACT.Data.Migrations.PDC
{
    public partial class UPDATE202110192024 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "PDC",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "UserInTeam",
                schema: "PDC",
                newName: "UserInTeam");

            migrationBuilder.RenameTable(
                name: "UserHoliday",
                schema: "PDC",
                newName: "UserHoliday");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "Topics",
                schema: "PDC",
                newName: "Topics");

            migrationBuilder.RenameTable(
                name: "TopicInProject",
                schema: "PDC",
                newName: "TopicInProject");

            migrationBuilder.RenameTable(
                name: "ToDoTask",
                schema: "PDC",
                newName: "ToDoTask");

            migrationBuilder.RenameTable(
                name: "TaskTypes",
                schema: "PDC",
                newName: "TaskTypes");

            migrationBuilder.RenameTable(
                name: "TaskItem",
                schema: "PDC",
                newName: "TaskItem");

            migrationBuilder.RenameTable(
                name: "TaskInKanban",
                schema: "PDC",
                newName: "TaskInKanban");

            migrationBuilder.RenameTable(
                name: "Sprint",
                schema: "PDC",
                newName: "Sprint");

            migrationBuilder.RenameTable(
                name: "SkillGroup",
                schema: "PDC",
                newName: "SkillGroup");

            migrationBuilder.RenameTable(
                name: "Skill",
                schema: "PDC",
                newName: "Skill");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "ProposalStatus",
                schema: "PDC",
                newName: "ProposalStatus");

            migrationBuilder.RenameTable(
                name: "Proposal",
                schema: "PDC",
                newName: "Proposal");

            migrationBuilder.RenameTable(
                name: "ProjectMember",
                schema: "PDC",
                newName: "ProjectMember");

            migrationBuilder.RenameTable(
                name: "ProjectItem",
                schema: "PDC",
                newName: "ProjectItem");

            migrationBuilder.RenameTable(
                name: "Priority",
                schema: "PDC",
                newName: "Priority");

            migrationBuilder.RenameTable(
                name: "OrganizationalRole",
                schema: "PDC",
                newName: "OrganizationalRole");

            migrationBuilder.RenameTable(
                name: "LocationsForAction",
                schema: "PDC",
                newName: "LocationsForAction");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "PDC",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "LocationInKanbans",
                schema: "PDC",
                newName: "LocationInKanbans");

            migrationBuilder.RenameTable(
                name: "LinesOfProducts",
                schema: "PDC",
                newName: "LinesOfProducts");

            migrationBuilder.RenameTable(
                name: "KanbanBoard",
                schema: "PDC",
                newName: "KanbanBoard");

            migrationBuilder.RenameTable(
                name: "FunctionalRole",
                schema: "PDC",
                newName: "FunctionalRole");

            migrationBuilder.RenameTable(
                name: "FinancialLineType",
                schema: "PDC",
                newName: "FinancialLineType");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubType",
                schema: "PDC",
                newName: "FinancialLineSubType");

            migrationBuilder.RenameTable(
                name: "FinancialLine",
                schema: "PDC",
                newName: "FinancialLine");

            migrationBuilder.RenameTable(
                name: "Entity",
                schema: "PDC",
                newName: "Entity");

            migrationBuilder.RenameTable(
                name: "Department",
                schema: "PDC",
                newName: "Department");

            migrationBuilder.RenameTable(
                name: "DeclarationSignature",
                schema: "PDC",
                newName: "DeclarationSignature");

            migrationBuilder.RenameTable(
                name: "Declarations",
                schema: "PDC",
                newName: "Declarations");

            migrationBuilder.RenameTable(
                name: "DeclarationRevision",
                schema: "PDC",
                newName: "DeclarationRevision");

            migrationBuilder.RenameTable(
                name: "Decision",
                schema: "PDC",
                newName: "Decision");

            migrationBuilder.RenameTable(
                name: "Currency",
                schema: "PDC",
                newName: "Currency");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                schema: "PDC",
                newName: "ContactPerson");

            migrationBuilder.RenameTable(
                name: "CommissionForProject",
                schema: "PDC",
                newName: "CommissionForProject");

            migrationBuilder.RenameTable(
                name: "Commission",
                schema: "PDC",
                newName: "Commission");

            migrationBuilder.RenameTable(
                name: "ChronogramText",
                schema: "PDC",
                newName: "ChronogramText");

            migrationBuilder.RenameTable(
                name: "ChronogramRevision",
                schema: "PDC",
                newName: "ChronogramRevision");

            migrationBuilder.RenameTable(
                name: "ChronogramLine",
                schema: "PDC",
                newName: "ChronogramLine");

            migrationBuilder.RenameTable(
                name: "CertificationLine",
                schema: "PDC",
                newName: "CertificationLine");

            migrationBuilder.RenameTable(
                name: "CertificationInActionItems",
                schema: "PDC",
                newName: "CertificationInActionItems");

            migrationBuilder.RenameTable(
                name: "CertificateProductLines",
                schema: "PDC",
                newName: "CertificateProductLines");

            migrationBuilder.RenameTable(
                name: "Certificate",
                schema: "PDC",
                newName: "Certificate");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                schema: "PDC",
                newName: "AuditLogs");

            migrationBuilder.RenameTable(
                name: "Audit",
                schema: "PDC",
                newName: "Audit");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "Identity",
                newName: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "AlertTypes",
                schema: "PDC",
                newName: "AlertTypes");

            migrationBuilder.RenameTable(
                name: "AlertInProject",
                schema: "PDC",
                newName: "AlertInProject");

            migrationBuilder.RenameTable(
                name: "ActivitySkill",
                schema: "PDC",
                newName: "ActivitySkill");

            migrationBuilder.RenameTable(
                name: "ActivityOrganizationalRole",
                schema: "PDC",
                newName: "ActivityOrganizationalRole");

            migrationBuilder.RenameTable(
                name: "ActivityInGroup",
                schema: "PDC",
                newName: "ActivityInGroup");

            migrationBuilder.RenameTable(
                name: "ActivityGroups",
                schema: "PDC",
                newName: "ActivityGroups");

            migrationBuilder.RenameTable(
                name: "ActivityFunctionalRole",
                schema: "PDC",
                newName: "ActivityFunctionalRole");

            migrationBuilder.RenameTable(
                name: "Activity",
                schema: "PDC",
                newName: "Activity");

            migrationBuilder.RenameTable(
                name: "ActionPlanRevision",
                schema: "PDC",
                newName: "ActionPlanRevision");

            migrationBuilder.RenameTable(
                name: "ActionItemLineOfProduct",
                schema: "PDC",
                newName: "ActionItemLineOfProduct");

            migrationBuilder.RenameTable(
                name: "ActionItem",
                schema: "PDC",
                newName: "ActionItem");

            migrationBuilder.RenameTable(
                name: "ActionGroups",
                schema: "PDC",
                newName: "ActionGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PDC");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "UserInTeam",
                newName: "UserInTeam",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "UserHoliday",
                newName: "UserHoliday",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Topics",
                newName: "Topics",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TopicInProject",
                newName: "TopicInProject",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ToDoTask",
                newName: "ToDoTask",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TaskTypes",
                newName: "TaskTypes",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TaskItem",
                newName: "TaskItem",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "TaskInKanban",
                newName: "TaskInKanban",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Sprint",
                newName: "Sprint",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "SkillGroup",
                newName: "SkillGroup",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Skill",
                newName: "Skill",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "ProposalStatus",
                newName: "ProposalStatus",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Proposal",
                newName: "Proposal",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ProjectMember",
                newName: "ProjectMember",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ProjectItem",
                newName: "ProjectItem",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Priority",
                newName: "Priority",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "OrganizationalRole",
                newName: "OrganizationalRole",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "LocationsForAction",
                newName: "LocationsForAction",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Locations",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "LocationInKanbans",
                newName: "LocationInKanbans",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "LinesOfProducts",
                newName: "LinesOfProducts",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "KanbanBoard",
                newName: "KanbanBoard",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FunctionalRole",
                newName: "FunctionalRole",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FinancialLineType",
                newName: "FinancialLineType",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FinancialLineSubType",
                newName: "FinancialLineSubType",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "FinancialLine",
                newName: "FinancialLine",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Entity",
                newName: "Entity",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Department",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationSignature",
                newName: "DeclarationSignature",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Declarations",
                newName: "Declarations",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "DeclarationRevision",
                newName: "DeclarationRevision",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Decision",
                newName: "Decision",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Currency",
                newName: "Currency",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ContactPerson",
                newName: "ContactPerson",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CommissionForProject",
                newName: "CommissionForProject",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Commission",
                newName: "Commission",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ChronogramText",
                newName: "ChronogramText",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ChronogramRevision",
                newName: "ChronogramRevision",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ChronogramLine",
                newName: "ChronogramLine",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CertificationLine",
                newName: "CertificationLine",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CertificationInActionItems",
                newName: "CertificationInActionItems",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "CertificateProductLines",
                newName: "CertificateProductLines",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Certificate",
                newName: "Certificate",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AuditLogs",
                newName: "AuditLogs",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Audit",
                newName: "Audit",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newName: "ApplicationUser",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AlertTypes",
                newName: "AlertTypes",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "AlertInProject",
                newName: "AlertInProject",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivitySkill",
                newName: "ActivitySkill",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityOrganizationalRole",
                newName: "ActivityOrganizationalRole",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityInGroup",
                newName: "ActivityInGroup",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityGroups",
                newName: "ActivityGroups",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActivityFunctionalRole",
                newName: "ActivityFunctionalRole",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "Activity",
                newName: "Activity",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionPlanRevision",
                newName: "ActionPlanRevision",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionItemLineOfProduct",
                newName: "ActionItemLineOfProduct",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionItem",
                newName: "ActionItem",
                newSchema: "PDC");

            migrationBuilder.RenameTable(
                name: "ActionGroups",
                newName: "ActionGroups",
                newSchema: "PDC");
        }
    }
}
