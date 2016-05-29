using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/divisions", HttpMethods.Get)]
    public class QueryDivisions : QueryDb<Division>
    {
        public int? Id { get; set; }
        public int? Number { get; set; }
        public int? Year { get; set; }
    }
}
