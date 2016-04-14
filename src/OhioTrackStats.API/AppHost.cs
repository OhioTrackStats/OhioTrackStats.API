using System;
using System.Collections.Generic;
using System.Linq;
using Funq;
using OhioTrackStats.API.ServiceInterface;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Admin;
using ServiceStack.Caching;
using ServiceStack.Data;
using ServiceStack.Logging;
using ServiceStack.Logging.Elmah;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.MySql;
using ServiceStack.Validation;

namespace OhioTrackStats.API
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("OhioTrackStats API", typeof(PlayerService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            var rsaKeyPair = RsaUtils.CreatePublicAndPrivateKeyPair(RsaKeyLengths.Bit4096);
            var privateKeyXml = rsaKeyPair.PrivateKey;

            this.Plugins.Add(new RequestLogsFeature());
            this.Plugins.Add(new ValidationFeature());
            this.Plugins.Add(new AutoQueryFeature { MaxLimit = 100 });
            this.Plugins.Add(new AdminFeature());
            this.Plugins.Add(new EncryptedMessagesFeature { PrivateKeyXml = privateKeyXml });

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", SqliteDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) });

            OrmLiteConfig.InsertFilter = (dbCmd, row) =>
            {
                var baseModel = row as BaseModel;
                if (baseModel != null)
                {
                    baseModel.DateInserted = DateTime.UtcNow;
                    baseModel.DateUpdated = DateTime.UtcNow;
                }
            };

            OrmLiteConfig.UpdateFilter = (dbCmd, row) =>
            {
                var baseModel = row as BaseModel;
                if (baseModel != null)
                {
                    baseModel.DateUpdated = DateTime.UtcNow;
                }
            };

            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                if (db.CreateTableIfNotExists<Player>())
                {
                    PlayerService.SeedData(db);
                }

                if (db.CreateTableIfNotExists<School>())
                {
                    SchoolService.SeedData(db);
                }

                if (db.CreateTableIfNotExists<Membership>())
                {
                    MembershipService.SeedData(db);
                }
            }
        }
    }
}