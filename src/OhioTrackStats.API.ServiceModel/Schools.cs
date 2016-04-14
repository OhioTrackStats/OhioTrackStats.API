using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/schools")]
    public class QuerySchools : QueryBase<School>
    {
    }
}
