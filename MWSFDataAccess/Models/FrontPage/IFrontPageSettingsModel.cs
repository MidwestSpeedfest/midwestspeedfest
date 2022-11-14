using System;

namespace MWSFDataAccess.Models.FrontPage
{
    public interface IFrontPageSettingsModel : IDatabaseModel
    {
        public string Author { get; set; }

        bool ShowLogo { get; set; }
        string HtmlContent { get; set; }

        bool ShowCountdown { get; set; }
        string CountdownTitle { get; set; }
        DateTime? CountdownUntil { get; set; }

        bool ShowAlert { get; set; }
        int? AlertId { get; set; }
    }
}