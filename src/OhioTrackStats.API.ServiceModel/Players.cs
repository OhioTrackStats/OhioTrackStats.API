using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/players")]
    public class QueryPlayers : QueryBase<Player>
    {
    }
}
