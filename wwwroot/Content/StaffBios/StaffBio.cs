using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidwestSpeedfest.wwwroot.Content.StaffBios
{
    public class StaffBio
    {
        internal string DisplayName { get; set; }
        internal string Pronouns { get; set; }
        internal string LogoUrl { get; set; }
        internal string Title { get; set; }
        internal string Twitter { get; set; }
        internal string SrcProfile { get; set; }
        internal string Description { get; set; }

        public StafBio(string displayName)
        {
            DisplayName = displayName;
            LogoUrl = $"Content/StaffBios/Logos/{DisplayName}.png";
        }
    }
}
