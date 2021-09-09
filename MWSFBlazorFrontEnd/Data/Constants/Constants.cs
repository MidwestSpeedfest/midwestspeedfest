﻿using System.Collections.Generic;

namespace MWSFBlazorFrontEnd.Data.Constants
{
    public static class Constants
    {
        internal static readonly List<string> RoleNamesList;

        static Constants()
        {
            //Dynamically scale list of role names as they are added
            var fields = typeof(RoleNames).GetFields();
            RoleNamesList = new List<string>();
            foreach (var fieldInfo in fields)
            {
                RoleNamesList.Add(fieldInfo.GetValue(typeof(RoleNames)).ToString());
            }
        }

        internal static class RoleNames
        {
            //These are public to so they can be used in Reflection
            public const string Admin = "Admin";
            public const string Staff = "Staff";
            public const string Volunteer = "Volunteer";
            public const string Runner = "Runner";
        }

        internal const string AdminLevelRoles = RoleNames.Admin + "," + RoleNames.Staff;
        internal const string VolunteerAndUp = AdminLevelRoles + "," + RoleNames.Volunteer;
        internal const string RunnerAndUp = VolunteerAndUp + "," + RoleNames.Runner;
    }
}
