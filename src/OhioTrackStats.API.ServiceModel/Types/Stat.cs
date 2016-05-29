using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    [CompositeIndex("PlayerId", "Approved")]
    [CompositeIndex("EventId", "Approved")]
    public class Stat : BaseModel
    {
        [Index(false)]
        public int PlayerId { get; set; }

        [Index(false)]
        public int EventId { get; set; }
        
        public bool Approved { get; set; }
    }
}
