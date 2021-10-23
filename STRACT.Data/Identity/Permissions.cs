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
}