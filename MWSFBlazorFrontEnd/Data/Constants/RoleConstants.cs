using System.Collections.Generic;
using MudBlazor;

namespace MWSFBlazorFrontEnd.Data.Constants
{
    public static class RoleConstants
    {
        public static readonly List<string> RoleNamesList;
        public static readonly string DefaultNewUserRoleName = RoleNames.User;

        static RoleConstants()
        {
            //Dynamically scale list of role names as they are added
            var fields = typeof(RoleNames).GetFields();
            RoleNamesList = new List<string>();
            foreach (var fieldInfo in fields)
            {
                RoleNamesList.Add(fieldInfo.GetValue(typeof(RoleNames)).ToString());
            }
        }

        public static class RoleNames
        {
            //These are public to so they can be used in Reflection
            public const string Admin = "Admin";
            public const string Staff = "Staff";
            public const string Volunteer = "Volunteer";
            public const string Runner = "Runner";
            public const string User = "User";
        }

        public static List<string> ProtectedRoles = new()
        {
            RoleNames.Staff
        };

        public const string AdminLevelRoles = RoleNames.Admin + "," + RoleNames.Staff;
        public const string VolunteerAndUp = AdminLevelRoles + "," + RoleNames.Volunteer;
        public const string RunnerAndUp = VolunteerAndUp + "," + RoleNames.Runner;

        public static readonly Dictionary<string, Color> RoleColors = new()
        {
            { RoleNames.Admin, Color.Warning },
            { RoleNames.Staff, Color.Secondary },
            { RoleNames.Volunteer, Color.Info },
            { RoleNames.Runner, Color.Success },
            { RoleNames.User, Color.Tertiary}
        };
    }
}
