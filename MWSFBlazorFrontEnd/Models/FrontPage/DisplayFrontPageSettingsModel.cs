using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MWSFDataAccess.Models.FrontPage;

namespace MWSFBlazorFrontEnd.Models.FrontPage
{
    public class DisplayFrontPageSettingsModel : IFrontPageSettingsModel
    {
        public ulong Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public string Author { get; set; }

        public bool ShowLogo { get; set; }
        public string HtmlContent { get; set; }

        public bool ShowCountdown { get; set; }
        public string CountdownTitle { get; set; }
        public DateTime? CountdownUntil { get; set; }

        public bool ShowAlert { get; set; }
        public int? AlertId { get; set; }
    }
}
