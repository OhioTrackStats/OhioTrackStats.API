using System;
using System.Security.Principal;
using Funq;
using OhioTrackStats.API.ServiceInterface;
using OhioTrackStats.API.ServiceModel.Types;
using ServiceStack;
using ServiceStack.Admin;
using ServiceStack.Caching;
using ServiceStack.Configuration;
using ServiceStack.Data;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite;
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
            this.Plugins.Add(new CorsFeature());

            IAppSettings appSettings = new AppSettings();

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(appSettings.Get<string>("Data.ConnectionString", "Server=localhost;Database=otsdb;User Id=sa;Password=Password!;"), SqlServerDialect.Provider) { ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current) });

            OrmLiteConfig.InsertFilter = (dbCmd, row) =>
            {
                var baseModel = row as BaseModel;
                if (baseModel != null)
                {
                    baseModel.DateInserted = DateTime.UtcNow;
                    baseModel.InsertedBy = WindowsIdentity.GetCurrent().Name;
                    baseModel.DateUpdated = DateTime.UtcNow;
                    baseModel.UpdatedBy = WindowsIdentity.GetCurrent().Name;
                }
            };

            OrmLiteConfig.UpdateFilter = (dbCmd, row) =>
            {
                var baseModel = row as BaseModel;
                if (baseModel != null)
                {
                    baseModel.DateUpdated = DateTime.UtcNow;
                    baseModel.UpdatedBy = WindowsIdentity.GetCurrent().Name;
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

                if (db.CreateTableIfNotExists<Event>())
                {
                    EventService.SeedData(db);
                }

                if (db.CreateTableIfNotExists<Stat>())
                {
                    StatService.SeedData(db);
                }

                if (db.CreateTableIfNotExists<Division>())
                {
                    DivisionService.SeedData(db);
                }
            }
        }
    }
}