using System;

namespace MWSFDataAccess.Models.Events
{
    public class EventModel : IEventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; } = DateTime.Now;
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public double MoneyRaised { get; set; }
        public string CharityName { get; set; }
        public string YouTubeLink {  get; set; }
    }
}
