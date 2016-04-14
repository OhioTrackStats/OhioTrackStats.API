using System;
using System.Data;
using System.Net;
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

        public object Delete(DeleteMembership request)
        {
            Db.DeleteById<Membership>(request.Id);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Post(CreateMembership request)
        {
            Db.Insert(request.Membership);
            return new HttpResult(HttpStatusCode.Created);
        }

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new Membership {PlayerId = 1, SchoolId = 1});
            db.Insert(new Membership {PlayerId = 2, SchoolId = 1});
        }
    }
}
