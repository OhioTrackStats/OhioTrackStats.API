using System.Data;
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
            db.Insert(new Event { Name = "100M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false});
            db.Insert(new Event { Name = "200M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "400M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "800M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "1600M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "3200M", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "100M Hurdles", IsMale = false, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "110M Hurdles", IsMale = true, IsFemale = false, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "300M Hurdles", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = false });
            db.Insert(new Event { Name = "4x100M Relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x200M Relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x400M Relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "4x800M Relay", IsMale = true, IsFemale = true, IsRunning = true, IsField = false, IsRelay = true });
            db.Insert(new Event { Name = "Shot Put", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Discus", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Long Jump", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "High Jump", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
            db.Insert(new Event { Name = "Pole Vault", IsMale = true, IsFemale = true, IsRunning = false, IsField = true, IsRelay = false });
        }
    }
}
