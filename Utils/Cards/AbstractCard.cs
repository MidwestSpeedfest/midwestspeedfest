using Microsoft.AspNetCore.Html;

namespace MidwestSpeedfest.Utils.Cards
{
    public abstract class AbstractCard : ICard
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }

        public abstract HtmlString GetCardHtml();
    }
}