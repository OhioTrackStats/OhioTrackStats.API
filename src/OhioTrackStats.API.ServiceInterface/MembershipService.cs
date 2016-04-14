using System;
using System.Data;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class MembershipService : Service
    {
        public IAutoQuery AutoQuery { get; set; }

        public object Get(QueryMemberships query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, this.Request));
        }

        public static void AddMemberships(IDbConnection db)
        {
            db.Insert(new Membership { Id = 1, Player = db.Select<Player>(x => x.Id == 1).FirstNonDefault(), School = db.Select<School>(x => x.Id == 1).FirstNonDefault(), DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
            db.Insert(new Membership { Id = 2, Player = db.Select<Player>(x => x.Id == 2).FirstNonDefault(), School = db.Select<School>(x => x.Id == 2).FirstNonDefault(), DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
        }
    }
}
