using System;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Player : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GradationYear { get; set; }
        public Gender Gender { get; set; }
    }
}
