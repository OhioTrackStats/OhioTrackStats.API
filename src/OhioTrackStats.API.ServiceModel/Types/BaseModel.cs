﻿using System;
using ServiceStack.DataAnnotations;

namespace OhioTrackStats.API.ServiceModel.Types
{
    public abstract class BaseModel
    {
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime DateInserted { get; set; }
        public string InsertedBy { get; set; }
        public DateTime DateUpdated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
