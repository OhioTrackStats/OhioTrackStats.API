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

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new School { Name = "Dover High School", City = "Dover", FemaleEnrollment = 150, MaleEnrollment = 150});
            db.Insert(new School { Name = "Cloverleaf High School", City = "Lodi", FemaleEnrollment = 125, MaleEnrollment = 125});
        }
    }
}
