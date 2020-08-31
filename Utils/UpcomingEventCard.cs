using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace MidwestSpeedfest.Utils
{
    public class UpcomingEventCard
    {
        private const string DefaultImagSrc = "Content/Images/MWSF_Logo.png";
        private const string DefaultAltText = "Midwest Speedfest Logo";
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }
        public string RunnerApplicationUrl { get; set; }


        public UpcomingEventCard(string title = "", string description = "", string runnerApplicationUrl = "")
        {
            Title = title;
            Description = description;
            RunnerApplicationUrl = runnerApplicationUrl;
        }

        public HtmlString GetCardHtml()
        {
            var ShouldUseDefaultImage = string.IsNullOrEmpty(ImageUrl);
            var sb = new StringBuilder();
            sb.AppendLine(@"<div class=""card upcoming-events-card bg-dark"">");
            sb.AppendLine(@"    <div class=""col-12"">");
            sb.AppendLine($@"       <img class=""card-img-top"" src=""{(ShouldUseDefaultImage ? DefaultImagSrc : ImageUrl)}"" alt=""{(ShouldUseDefaultImage ? DefaultAltText : AltText)}"">");
            sb.AppendLine(@"    </div>");
            sb.AppendLine(@"    <div class=""card-body"">");
            sb.AppendLine($@"       <h4 class=""card-title"">{Title}</h5>");
            sb.AppendLine($@"       <p class=""card-text"">{Description}</p>");
            if (!string.IsNullOrEmpty(RunnerApplicationUrl))
            {
                sb.AppendLine($@"       <a href=""{RunnerApplicationUrl}""Apply");
            }

            sb.AppendLine(@"    </div>");
            sb.AppendLine(@"</div>");


            return new HtmlString(sb.ToString());
        }
        
    }
}
