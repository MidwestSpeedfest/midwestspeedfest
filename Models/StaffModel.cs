using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidwestSpeedfest.Models
{
    public class StaffModel
    {
        public string DisplayName { get; set; }
        public string Pronouns { get; set; }
        public string LogoUrl { get; set; }
        public string[] Titles { get; set; }
        public string Twitch { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string SrcProfile { get; set; }
        public string Description { get; set; }
    }
}
