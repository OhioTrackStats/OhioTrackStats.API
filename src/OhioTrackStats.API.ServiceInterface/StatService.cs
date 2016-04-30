using System.Data;
using System.Net;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class StatService : Service
    {
        public IAutoQueryDb AutoQuery { get; set; }

        public object Get(QueryStats query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, this.Request));
        }

        public object Delete(DeleteStat request)
        {
            Db.DeleteById<Stat>(request.Id);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Post(CreateStat request)
        {
            request.Stat.Approved = false;
            Db.Insert(request.Stat);
            return new HttpResult(HttpStatusCode.Created);
        }

        public static void SeedData(IDbConnection db)
        {
            
        }
    }
}
