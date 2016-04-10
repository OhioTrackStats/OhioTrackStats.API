using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/memberships")]
    public class QueryMemberships : QueryBase<Membership>
    {
    }
}
