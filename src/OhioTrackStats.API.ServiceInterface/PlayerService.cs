﻿using System;
using System.Data;
using System.Net;
using OhioTrackStats.API.ServiceModel;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.OrmLite;

namespace OhioTrackStats.API.ServiceInterface
{
    public class PlayerService : Service
    {
        public IAutoQuery AutoQuery { get; set; }

        public object Get(QueryPlayers query)
        {
            return AutoQuery.Execute(query, AutoQuery.CreateQuery(query, Request));
        }

        public object Put(UpdatePlayer request)
        {
            Db.Update(request.Player);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Delete(DeletePlayer request)
        {
            Db.DeleteById<Player>(request.Id);
            return new HttpResult(HttpStatusCode.OK);
        }

        public object Post(CreatePlayer request)
        {
            Db.Insert(request.Player);
            return new HttpResult(HttpStatusCode.Created);
        }

        public static void SeedData(IDbConnection db)
        {
            db.Insert(new Player {FirstName = "Tommie", LastName = "Kurtz", Gender = Gender.Female, GraduationYear = 2019});
            db.Insert(new Player {FirstName = "Matt", LastName = "Butt", Gender = Gender.Male, GraduationYear = 2017});
            db.Insert(new Player {FirstName = "Joey", LastName = "Kurtz", Gender = Gender.Male, GraduationYear = 2020});
        }
    }
}
