using System;

namespace MWSFDataAccess.Models.FrontPage
{
    public interface IFrontPageSettingsModel
    {
        int Id { get; set; }
        DateTime? Created { get; set; }
        DateTime? Modified { get; set; }
        public string Author { get; set; }

        bool ShowLogo { get; set; }
        string HtmlContent { get; set; }

        bool ShowCountdown { get; set; }
        string CountdownTitle { get; set; }
        DateTime? CountdownUntil { get; set; }
    }
}