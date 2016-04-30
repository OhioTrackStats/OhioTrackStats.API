using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/events", HttpMethods.Get)]
    public class QueryEvents : QueryDb<Event>
    {
    }

    [Route("/events/{id}", HttpMethods.Delete)]
    public class DeleteEvent
    {
        public int Id { get; set; }
    }

    [Route("/events", HttpMethods.Post)]
    public class CreateEvent
    {
        public Event Event { get; set; }
    }
}
