using System;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class School : BaseModel
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int FemaleEnrollment { get; set; }
        public int MaleEnrollment { get; set; }
    }
}