namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public EventType EventType { get; set; }
    }
}
