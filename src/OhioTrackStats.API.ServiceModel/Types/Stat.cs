namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Stat : BaseModel
    {
        public int PlayerId { get; set; }
        public int EventId { get; set; }
        public bool Approved { get; set; }
    }
}
