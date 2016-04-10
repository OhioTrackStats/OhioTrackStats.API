using System;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
