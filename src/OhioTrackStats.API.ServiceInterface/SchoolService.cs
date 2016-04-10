using System;
using System.Data;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class SchoolService : Service
    {
        public IAutoQuery AutoQuery { get; set; }

        public object Get(QuerySchools query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, Request));
        }

        public static void AddSchools(IDbConnection db)
        {
            db.Insert(new School { Id = 1, Name = "Dover High School", City = "Dover", FemaleEnrollment = 150, MaleEnrollment = 150, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow});
            db.Insert(new School { Id = 2, Name = "Cloverleaf High School", City = "Lodi", FemaleEnrollment = 125, MaleEnrollment = 125, DateInserted = DateTime.UtcNow, DateUpdated = DateTime.UtcNow });
        }
    }
}
