using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using MidwestSpeedfest.Models;

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

    public class StaffCard : AbstractCard
    {
        public StaffModel StaffMember;

        public StaffCard(string key)
        {
            SetStaffMember(key);
        }

        protected void SetStaffMember(string key)
        {
            StaffMember = StaffUtils.GetStaffMemberFromJson(key);
        }

        public override HtmlString GetCardHtml()
        {
            throw new System.NotImplementedException();
        }
    }

    public class StaffSelectCard : StaffCard
    {
        public StaffSelectCard(string key) : base(key)
        {
        }

        public override HtmlString GetCardHtml()
        {
            throw new System.NotImplementedException();
        }


    }
}