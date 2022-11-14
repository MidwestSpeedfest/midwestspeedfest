using MWSFDataAccess.Models.Events;
using System;

namespace MWSFBlazorFrontEnd.Models.Events
{
    public class EventDisplayModel : IEventModel
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public double MoneyRaised { get; set; }
        public string CharityName { get; set; }
        public string YouTubeLink { get; set; }
    }
}
