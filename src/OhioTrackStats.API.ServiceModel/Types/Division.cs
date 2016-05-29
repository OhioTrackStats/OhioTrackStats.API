using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Division : BaseModel
    {
        public int Number { get; set; }
        public int MaleMinimumEnrollment { get; set; }
        public int MaleMaximumEnrollment { get; set; }
        public int FemaleMinimumEnrollment { get; set; }
        public int FemaleMaximumEnrollment { get; set; }
        public int Year { get; set; }
    }
}
