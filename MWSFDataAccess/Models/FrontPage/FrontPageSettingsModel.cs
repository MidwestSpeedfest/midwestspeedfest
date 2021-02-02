using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWSFDataAccess.Models.FrontPage
{
    public class FrontPageSettingsModel : IFrontPageSettingsModel
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Author { get; set; }

        public bool ShowLogo { get; set; }
        public string Headline { get; set; }
        public string Details { get; set; }

        public bool ShowCountdown { get; set; }
        public string CountdownTitle { get; set; }
        public DateTime? CountdownUntil { get; set; }
    }
}
