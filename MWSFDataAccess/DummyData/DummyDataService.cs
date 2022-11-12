using MWSFDataAccess.Models.Events;
using System;
using System.Collections.Generic;

namespace MWSFDataAccess.DummyData
{
    public class DummyDataService : IDummyDataService
    {
        public List<EventModel> GetDummyEvents()
        {
            return DummyEvents;
        }


        private static List<EventModel> DummyEvents = new List<EventModel>
        {
            new EventModel()
            {
                Name = "Try to screw Up The Order 2008",
                EventStart = DateTime.Parse("August 13, 2008"),
                EventEnd = DateTime.Parse("August 15, 2008"),
                CharityName = "People messing up the date order",
                MoneyRaised = 1234
            },
            new EventModel()
            {
                Name = "Midwest Speedfest 2022",
                EventStart = DateTime.Parse("August 26, 2022"),
                EventEnd = DateTime.Parse("August 28, 2022"),
                CharityName = "Creators Against Childhood Cancer",
                MoneyRaised = 5170
            },
            new EventModel()
            {
                Name = "Midspring Speedfling",
                EventStart = DateTime.Parse("April 1, 2022"),
                EventEnd = DateTime.Parse("April 3, 2022"),
                CharityName = "Save the music or something",
                MoneyRaised = 8675309
            },
            new EventModel()
            {
                Name = "Dan's Cool Event",
                EventStart = DateTime.Parse("June 25, 1984"),
                EventEnd = DateTime.Parse("June 27, 1984"),
                CharityName = "idk something for kids",
                MoneyRaised = 9001
            },
            new EventModel()
            {
                Name = "Ghostbusters",
                EventStart = DateTime.Parse("June 8, 1984"),
                EventEnd = DateTime.Parse("June 10, 1984"),
                CharityName = "Columbia Pictures",
                MoneyRaised = 295000000
            }
        };
    }
}
