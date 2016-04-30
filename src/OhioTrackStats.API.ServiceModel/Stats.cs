using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/stats", HttpMethods.Get)]
    public class QueryStats : QueryBase<Stat>, IJoin<Stat, Player>, IJoin<Stat, School>
    {
    }

    [Route("/stats/{id}", HttpMethods.Delete)]
    public class DeleteStat
    {
        public int Id { get; set; }
    }

    [Route("/stats", HttpMethods.Post)]
    public class CreateStat
    {
        public Stat Stat { get; set; }
    }
}
