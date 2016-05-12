﻿using System.Data;
using System.Net;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class EventService : Service
    {
        public IAutoQueryDb AutoQuery { get; set; }

        public object Get(QueryEvents query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, this.Request));
        }

        public object Delete(DeleteEvent request)
        {
            Db.DeleteById<Event>(request.Id);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Post(CreateEvent request)
        {
            Db.Insert(request.Event);
            return new HttpResult(HttpStatusCode.Created);
        }

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new Event { Name = "100M", ShortName = "100m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false});
            db.Insert(new Event { Name = "200M", ShortName = "200m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "400M", ShortName = "400m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "800M", ShortName = "800m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "1600M", ShortName = "1600m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "3200M", ShortName = "3200m", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "100M Hurdles", ShortName = "100m-hurdles", IsMale = false, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "110M Hurdles", ShortName = "110m-hurdles", IsMale = true, IsFemale = false, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "300M Hurdles", ShortName = "300m-hurdles", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "4x100M Relay", ShortName = "4x100m-relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x200M Relay", ShortName = "4x200m-relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x400M Relay", ShortName = "4x400m-relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x800M Relay", ShortName = "4x800m-relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "Shot Put", ShortName = "shot-put", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Discus", ShortName = "discus", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Long Jump", ShortName = "long-jump", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "High Jump", ShortName = "high-jump", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Pole Vault", ShortName = "pole-vault", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
        }
    }
}
