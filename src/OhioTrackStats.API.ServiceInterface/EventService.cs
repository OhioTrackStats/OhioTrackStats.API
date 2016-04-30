using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            db.Insert(new Event { Name = "100M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "200M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "400M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "800M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "1600M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "3200M", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "100M Hurdles", Gender = Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "110M Hurdles", Gender = Gender.Male, EventType = EventType.Running });
            db.Insert(new Event { Name = "300M Hurdles", Gender = Gender.Male | Gender.Female, EventType = EventType.Running });
            db.Insert(new Event { Name = "4x100M Relay", Gender = Gender.Male | Gender.Female, EventType = EventType.Running | EventType.Relay });
            db.Insert(new Event { Name = "4x200M Relay", Gender = Gender.Male | Gender.Female, EventType = EventType.Running | EventType.Relay });
            db.Insert(new Event { Name = "4x400M Relay", Gender = Gender.Male | Gender.Female, EventType = EventType.Running | EventType.Relay });
            db.Insert(new Event { Name = "4x800M Relay", Gender = Gender.Male | Gender.Female, EventType = EventType.Running | EventType.Relay });
            db.Insert(new Event { Name = "Shot Put", Gender = Gender.Male | Gender.Female, EventType = EventType.Field });
            db.Insert(new Event { Name = "Discus", Gender = Gender.Male | Gender.Female, EventType = EventType.Field });
            db.Insert(new Event { Name = "Long Jump", Gender = Gender.Male | Gender.Female, EventType = EventType.Field });
            db.Insert(new Event { Name = "High Jump", Gender = Gender.Male | Gender.Female, EventType = EventType.Field });
            db.Insert(new Event { Name = "Pole Vault", Gender = Gender.Male | Gender.Female, EventType = EventType.Field });
        }
    }
}
