using System.Collections.Generic;

public static class Permissions
{
    public static List<string> GeneratePermissionsForModule(string module)
    {
        return new List<string>()
        {
            $"Permissions.{module}.Create",
            $"Permissions.{module}.View",
            $"Permissions.{module}.Edit",
            $"Permissions.{module}.Delete",
        };
    }
    public static class Declarations
    {
        public const string View = "Permissions.Declarations.View";
        public const string Create = "Permissions.Declarations.Create";
        public const string Edit = "Permissions.Declarations.Edit";
        public const string Delete = "Permissions.Declarations.Delete";
    }
    public static class RoleManager
    {
        public const string View = "Permissions.RoleManager.View";
        public const string Create = "Permissions.RoleManager.Create";
        public const string Edit = "Permissions.RoleManager.Edit";
        public const string Delete = "Permissions.RoleManager.Delete";
    }
    public static class ActionGroups
    {
        public const string View = "Permissions.ActionGroups.View";
        public const string Create = "Permissions.ActionGroups.Create";
        public const string Edit = "Permissions.ActionGroups.Edit";
        public const string Delete = "Permissions.ActionGroups.Delete";
    }
    public static class AlertTypes
    {
        public const string View = "Permissions.AlertTypes.View";
        public const string Create = "Permissions.AlertTypes.Create";
        public const string Edit = "Permissions.AlertTypes.Edit";
        public const string Delete = "Permissions.AlertTypes.Delete";
    }
    public static class LineOfProducts
    {
        public const string View = "Permissions.LineOfProducts.View";
        public const string Create = "Permissions.LineOfProducts.Create";
        public const string Edit = "Permissions.LineOfProducts.Edit";
        public const string Delete = "Permissions.LineOfProducts.Delete";
    }
    public static class Locations
    {
        public const string View = "Permissions.Locations.View";
        public const string Create = "Permissions.Locations.Create";
        public const string Edit = "Permissions.Locations.Edit";
        public const string Delete = "Permissions.Locations.Delete";
    }
    public static class Topics
    {
        public const string View = "Permissions.Topics.View";
        public const string Create = "Permissions.Topics.Create";
        public const string Edit = "Permissions.Topics.Edit";
        public const string Delete = "Permissions.Topics.Delete";
    }
    public static class Currencies
    {
        public const string View = "Permissions.Currencies.View";
        public const string Create = "Permissions.Currencies.Create";
        public const string Edit = "Permissions.Currencies.Edit";
        public const string Delete = "Permissions.Currencies.Delete";
    }
    public static class FinancialLineTypes
    {
        public const string View = "Permissions.FinancialLineTypes.View";
        public const string Create = "Permissions.FinancialLineTypes.Create";
        public const string Edit = "Permissions.FinancialLineTypes.Edit";
        public const string Delete = "Permissions.FinancialLineTypes.Delete";
    }
    public static class FinancialLineSubTypes
    {
        public const string View = "Permissions.FinancialLineSubTypes.View";
        public const string Create = "Permissions.FinancialLineSubTypes.Create";
        public const string Edit = "Permissions.FinancialLineSubTypes.Edit";
        public const string Delete = "Permissions.FinancialLineSubTypes.Delete";
    }
    public static class Activities
    {
        public const string View = "Permissions.Activities.View";
        public const string Create = "Permissions.Activities.Create";
        public const string Edit = "Permissions.Activities.Edit";
        public const string Delete = "Permissions.Activities.Delete";
    }
    public static class ActivityGroups
    {
        public const string View = "Permissions.ActivityGroups.View";
        public const string Create = "Permissions.ActivityGroups.Create";
        public const string Edit = "Permissions.ActivityGroups.Edit";
        public const string Delete = "Permissions.ActivityGroups.Delete";
    }
    public static class Departments
    {
        public const string View = "Permissions.Departments.View";
        public const string Create = "Permissions.Departments.Create";
        public const string Edit = "Permissions.Departments.Edit";
        public const string Delete = "Permissions.Departments.Delete";
    }
    public static class SkillGroups
    {
        public const string View = "Permissions.SkillGroups.View";
        public const string Create = "Permissions.SkillGroups.Create";
        public const string Edit = "Permissions.SkillGroups.Edit";
        public const string Delete = "Permissions.SkillGroups.Delete";
    }
    public static class Skills
    {
        public const string View = "Permissions.Skills.View";
        public const string Create = "Permissions.Skills.Create";
        public const string Edit = "Permissions.Skills.Edit";
        public const string Delete = "Permissions.Skills.Delete";
    }
    public static class FunctionalRoles
    {
        public const string View = "Permissions.FunctionalRoles.View";
        public const string Create = "Permissions.FunctionalRoles.Create";
        public const string Edit = "Permissions.FunctionalRoles.Edit";
        public const string Delete = "Permissions.FunctionalRoles.Delete";
    }
    public static class OrganizationalRoles
    {
        public const string View = "Permissions.OrganizationalRoles.View";
        public const string Create = "Permissions.OrganizationalRoles.Create";
        public const string Edit = "Permissions.OrganizationalRoles.Edit";
        public const string Delete = "Permissions.OrganizationalRoles.Delete";
    }
}