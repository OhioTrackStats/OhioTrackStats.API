using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/players")]
    public class QueryPlayers : QueryBase<Player>
    {
    }

    [Route("/players")]
    public class UpdatePlayer
    {
        public Player Player { get; set; }
    }

    [Route("/players/{PlayerId}")]
    public class DeletePlayer
    {
        public int PlayerId { get; set; }
    }

    [Route("/players")]
    public class CreatePlayer
    {
        public Player Player { get; set; }
    }
}
