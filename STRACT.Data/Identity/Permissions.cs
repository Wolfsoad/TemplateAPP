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


}