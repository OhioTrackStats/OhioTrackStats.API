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

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new Membership {PlayerId = 1, SchoolId = 1});
            db.Insert(new Membership {PlayerId = 2, SchoolId = 1});
        }
    }
}
