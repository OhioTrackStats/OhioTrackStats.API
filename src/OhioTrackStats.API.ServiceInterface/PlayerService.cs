using System;
using System.Data;
using System.Net;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class PlayerService : Service
    {
        public IAutoQuery AutoQuery { get; set; }

        public object Get(QueryPlayers query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, Request));
        }

        public object Put(UpdatePlayer request)
        {
            Db.Update(request.Player);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Delete(DeletePlayer request)
        {
            Db.DeleteById<Player>(request.PlayerId);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Post(CreatePlayer request)
        {
            Db.Insert(request.Player);
            return new HttpResult(HttpStatusCode.Created);
        }

        public static void AddPlayers(IDbConnection db)
        {
            db.Insert(new Player {Id = 1, FirstName = "Tommie", LastName = "Kurtz", Gender = Gender.Female, GradationYear = 2019, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
            db.Insert(new Player {Id = 2, FirstName = "Matt", LastName = "Butt", Gender = Gender.Male, GradationYear = 2017, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
            db.Insert(new Player {Id = 3, FirstName = "Joey", LastName = "Kurtz", Gender = Gender.Male, GradationYear = 2020, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
        }
    }
}
