using System;
using System.Data;
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

        public static void AddPlayers(IDbConnection db)
        {
            db.Insert(new Player {Id = 1, FirstName = "Tommie", LastName = "Kurtz", Gender = Gender.Female, GradationYear = 2019, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
            db.Insert(new Player {Id = 2, FirstName = "Matt", LastName = "Butt", Gender = Gender.Male, GradationYear = 2017, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
            db.Insert(new Player {Id = 3, FirstName = "Joey", LastName = "Kurtz", Gender = Gender.Male, GradationYear = 2020, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
        }
    }
}
