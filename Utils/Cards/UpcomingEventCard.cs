using System.Text;
using Microsoft.AspNetCore.Html;

namespace MidwestSpeedfest.Utils.Cards
{
    public class UpcomingEventAbstractCard : AbstractCard
    {
        private const string DefaultImagSrc = "Content/Images/MWSF_Logo.png";
        private const string DefaultAltText = "Midwest Speedfest Logo";
        public string RunnerApplicationUrl { get; set; }


        public UpcomingEventAbstractCard(string title = "", string description = "", string runnerApplicationUrl = "")
        {
            Title = title;
            Description = description;
            RunnerApplicationUrl = runnerApplicationUrl;
        }

        public override HtmlString GetCardHtml()
        {
            var ShouldUseDefaultImage = string.IsNullOrEmpty(ImageUrl);
            var sb = new StringBuilder();
            sb.AppendLine(@"<div class=""card upcoming-events-card bg-dark"">");
            sb.AppendLine(@"    <div class=""col-12"">");
            sb.AppendLine($@"       <img class=""card-img-top"" src=""{(ShouldUseDefaultImage ? DefaultImagSrc : ImageUrl)}"" alt=""{(ShouldUseDefaultImage ? DefaultAltText : AltText)}"">");
            sb.AppendLine(@"    </div>");
            sb.AppendLine(@"    <div class=""card-body"">");
            sb.AppendLine($@"       <h4 class=""card-title"">{Title}</h4>");
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
