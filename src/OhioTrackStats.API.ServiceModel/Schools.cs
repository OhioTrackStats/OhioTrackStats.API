using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/schools", HttpMethods.Get)]
    public class QuerySchools : QueryBase<School>
    {
    }

    [Route("/schools", HttpMethods.Put)]
    public class UpdateSchool
    {
        public School School { get; set; }
    }

    [Route("/schools/{SchoolId}", HttpMethods.Delete)]
    public class DeleteSchool
    {
        public int SchoolId { get; set; }
    }

    [Route("/schools", HttpMethods.Post)]
    public class CreateSchool
    {
        public School School { get; set; }
    }
}
