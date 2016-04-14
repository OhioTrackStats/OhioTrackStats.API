using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/memberships", HttpMethods.Get)]
    public class QueryMemberships : QueryBase<Membership>, IJoin<Player, Membership>, IJoin<School, Membership>
    {
    }

    [Route("/memberships/{id}", HttpMethods.Delete)]
    public class DeleteMembership
    {
        public int Id { get; set; }
    }

    [Route("/memberships", HttpMethods.Post)]
    public class CreateMembership
    {
        public Membership Membership { get; set; }
    }
}
