using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/events", HttpMethods.Get)]
    public class QueryEvents : QueryDb<Event>
    {
        public int? Id { get; set; }
        public bool? IsMale { get; set; }
        public bool? IsFemale { get; set; }
        public bool? IsRunning { get; set; }
        public bool? IsField { get; set; }
        public bool? IsRelay { get; set; }
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
