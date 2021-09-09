using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MWSFBlazorFrontEnd.Data.Constants
{
    public static class Constants
    {
        internal static class RoleNames
        {
            internal const string Admin = "Admin";
            internal const string Staff = "Staff";
            internal const string Volunteer = "Volunteer";
            internal const string Runner = "Runner";
        }

        public static readonly List<string> RoleNamesList = new List<string>  
        {
            RoleNames.Admin,
            RoleNames.Staff,
            RoleNames.Volunteer,
            RoleNames.Runner
        };

        public const string AdminLevelRoles = RoleNames.Admin + "," + RoleNames.Staff;
        public const string VolunteerAndUp = AdminLevelRoles + "," + RoleNames.Volunteer;
        public static readonly string RunnerAndUp = VolunteerAndUp + "," + RoleNames.Runner;
    }
}
