using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MidwestSpeedfest.Utils;
using MidwestSpeedfest.Utils.Cards;

namespace MidwestSpeedfest.Pages
{
    public class UpcomingEventsModel : PageModel
    {
        public List<HtmlString> Cards = new List<HtmlString>();

        public void OnGet()
        {
            PopulateUpcomingEventCards();
        }

        private void PopulateUpcomingEventCards()
        {
            Cards.Add(
                new UpcomingEventAbstractCard
                {
                    Title = "MidFall SpeedBall",
                    ImageUrl = null,
                    AltText = null,
                    Description = @"Midfall Speedball will be a charity speedrun marathon running from November 20-22, 2020. <br/> <br/> <a href=""https://www.speedrun.com/mfsb2020/submitrun"" a> Apply Here </a> ",
                    RunnerApplicationUrl = null
                }.GetCardHtml()
            );
        }
    }
}
