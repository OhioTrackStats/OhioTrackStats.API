using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Membership : BaseModel
    {
        public int PlayerId { get; set; }
        public int SchoolId { get; set; }
    }
}
