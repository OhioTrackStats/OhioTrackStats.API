using ServiceStack.Support.Markdown;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Event : BaseModel
    {
        public string Name { get; set; }
        public string ShortName => this.Name.ToLower().Replace(" ", "-");
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public bool IsRunning { get; set; }
        public bool IsField { get; set; }
        public bool IsRelay { get; set; }
    }
}
