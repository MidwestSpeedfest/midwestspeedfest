using System.Text;
using Microsoft.AspNetCore.Html;

namespace MidwestSpeedfest.Utils.Cards
{
    public class StaffBioCard : StaffCard
    {
        public StaffBioCard(string key) : base(key)
        {
        }

        public override HtmlString GetCardHtml()
        {
            var sb = new StringBuilder();
            sb.AppendLine(@"<div class=""card upcoming-events-card bg-dark"">");
            if (!string.IsNullOrEmpty(ImageUrl))
            {
                sb.AppendLine(@"    <div class=""col-12"">");
                sb.AppendLine($@"       <img class=""card-img-top"" src={ImageUrl} alt={AltText}");
                sb.AppendLine(@"    </div>");
            }
            sb.AppendLine(@"    <div class=""card-body"">");
            sb.AppendLine($@"       <h4 class=""card-title"">{Title}</h4>");
            sb.AppendLine($@"       <p class=""card-text"">{Description}</p>");
            sb.AppendLine(@"    </div>");
            sb.AppendLine(@"</div>");

            throw new System.NotImplementedException();
        }


    }
}