namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Membership : BaseModel
    {
        public Player Player { get; set; }
        public School School { get; set; }
    }
}
