using MWSFDataAccess.Models.Events;

namespace MWSFLogic.Events
{
    public interface IEventHandler
    {
        void CreateEvent();
        EventModel GetEvent(int id);
        EventModel GetEvent(string name);
        List<EventModel> GetEvents();
        List<EventModel> GetActiveEvents();
             
    }
}
