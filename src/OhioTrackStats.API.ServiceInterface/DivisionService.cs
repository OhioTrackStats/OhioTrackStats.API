using System.Data;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class DivisionService : Service
    {
        public IAutoQueryDb AutoQuery { get; set; }

        public object Get(QueryDivisions query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, this.Request));
        }

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new Division { Number = 1, MaleMinimumEnrollment = 293, MaleMaximumEnrollment = 9999, FemaleMinimumEnrollment = 287, FemaleMaximumEnrollment = 9999 });
            db.Insert(new Division { Number = 2, MaleMinimumEnrollment = 151, MaleMaximumEnrollment = 292, FemaleMinimumEnrollment = 147, FemaleMaximumEnrollment = 286 });
            db.Insert(new Division { Number = 3, MaleMinimumEnrollment = 0, MaleMaximumEnrollment = 150, FemaleMinimumEnrollment = 0, FemaleMaximumEnrollment = 146 });
        }
    }
}
