using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Event : BaseModel
    {
        public string Name { get; set; }

        [Index(true)]
        public string ShortName { get; set; }

        [Index(false)]
        public bool IsMale { get; set; }

        [Index(false)]
        public bool IsFemale { get; set; }
        public bool IsRunning { get; set; }
        public bool IsField { get; set; }
        public bool IsRelay { get; set; }
    }
}
