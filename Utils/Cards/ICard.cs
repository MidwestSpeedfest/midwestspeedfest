using Microsoft.AspNetCore.Html;

namespace MidwestSpeedfest.Utils.Cards
{
    public interface ICard
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }

    }
}