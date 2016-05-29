using System.Collections.Generic;
using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public class Player : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GraduationYear { get; set; }

        [Index(false)]
        public bool IsMale { get; set; }

        [Index(false)]
        public bool IsFemale { get; set; }

        [Reference]
        public List<Membership> Memberships { get; set; }

        [Reference]
        public List<Stat> Stats { get; set; }
    }
}
