using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class School : BaseModel
    {
        public string Name { get; set; }
        public string City { get; set; }

        [Index(false)]
        public int FemaleEnrollment { get; set; }

        [Index(false)]
        public int MaleEnrollment { get; set; }

        [Reference]
        public List<Membership> Memberships { get; set; }
    }
}