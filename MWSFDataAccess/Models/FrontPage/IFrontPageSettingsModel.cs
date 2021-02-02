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
        string Headline { get; set; }
        string Details { get; set; }

        bool ShowCountdown { get; set; }
        string CountdownTitle { get; set; }
        DateTime? CountdownUntil { get; set; }
    }
}