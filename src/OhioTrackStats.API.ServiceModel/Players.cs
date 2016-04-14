using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Html;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/players", HttpMethods.Get)]
    public class QueryPlayers : QueryBase<Player>
    {
    }

    [Route("/players", HttpMethods.Put)]
    public class UpdatePlayer
    {
        public Player Player { get; set; }
    }

    [Route("/players/{PlayerId}", HttpMethods.Delete)]
    public class DeletePlayer
    {
        public int PlayerId { get; set; }
    }

    [Route("/players", HttpMethods.Post)]
    public class CreatePlayer
    {
        public Player Player { get; set; }
    }
}
