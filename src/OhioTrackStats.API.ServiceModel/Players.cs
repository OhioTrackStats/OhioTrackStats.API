﻿using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;

namespace OhioTrackStats.API.ServiceModel
{
    [Route("/players", HttpMethods.Get)]
    public class QueryPlayers : QueryDb<Player>
    {
    }

    [Route("/players", HttpMethods.Put)]
    public class UpdatePlayer
    {
        public Player Player { get; set; }
    }

    [Route("/players/{id}", HttpMethods.Delete)]
    public class DeletePlayer
    {
        public int Id { get; set; }
    }

    [Route("/players", HttpMethods.Post)]
    public class CreatePlayer
    {
        public Player Player { get; set; }
    }
}
