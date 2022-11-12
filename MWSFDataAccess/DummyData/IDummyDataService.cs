using MWSFDataAccess.Models.Events;
using System.Collections.Generic;


namespace MWSFDataAccess.DummyData
{ 
    /*****
    This class is used for generating dummy data during development and unit testing.
    Do not use this for production.
    ******/
    public interface IDummyDataService
    {
        List<EventModel> GetDummyEvents();
    }
}
