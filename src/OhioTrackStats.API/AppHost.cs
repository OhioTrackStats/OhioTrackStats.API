using System;
using Funq;
using ServiceStack;
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
        public AppHost() : base("OhioTrackStats API", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            var rsaKeyPair = RsaUtils.CreatePublicAndPrivateKeyPair(RsaKeyLengths.Bit4096);
            var privateKeyXml = rsaKeyPair.PrivateKey;

            this.Plugins.Add(new RequestLogsFeature());
            this.Plugins.Add(new ValidationFeature());
            this.Plugins.Add(new EncryptedMessagesFeature { PrivateKeyXml = privateKeyXml });

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(":memory:", MySqlDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)   });
        }
    }
}