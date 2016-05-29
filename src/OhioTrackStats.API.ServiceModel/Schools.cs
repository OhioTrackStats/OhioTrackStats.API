using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/schools", HttpMethods.Get)]
    public class QuerySchools : QueryDb<School>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Division Division { get; set; }
    }

    [Route("/schools", HttpMethods.Put)]
    public class UpdateSchool
    {
        public School School { get; set; }
    }

    [Route("/schools/{id}", HttpMethods.Delete)]
    public class DeleteSchool
    {
        public int Id { get; set; }
    }

    [Route("/schools", HttpMethods.Post)]
    public class CreateSchool
    {
        public School School { get; set; }
    }
}
