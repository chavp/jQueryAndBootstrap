using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisa.BusinessModels.Test
{
    using Cwn.eVisa.NH.Mappings;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Driver;
    using NHibernate.Tool.hbm2ddl;

    public static class DBHelper
    {
        public static ISessionFactory CreateOracleSessionFactory()
        {
            //Install http://www.oracle.com/technetwork/topics/dotnet/index-085163.html
            //Install-Package odp.net.managed
            //Install-Package FluentNHibernate

            var c = Fluently.Configure();
            c.Database(OracleDataClientConfiguration.Oracle10
              .ConnectionString(x => x.FromConnectionStringWithKey("default"))
              .Driver<OracleManagedDataClientDriver>()
              .DefaultSchema("MFAFRONT"));
            c.Mappings(m => m.FluentMappings.AddFromAssemblyOf<EApplicationVisaMap>());
            return c.ExposeConfiguration(TreatConfiguration).BuildSessionFactory();

            //return Fluently.Configure(config)
            //    .Database(OracleClientConfiguration.Oracle10
            //    .ConnectionString(x => x.FromConnectionStringWithKey("ConnString"))
            //    .Provider<DriverConnectionProvider>()
            //    .Driver<OracleClientDriver>())
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UnitTest1>())
            //    .ExposeConfiguration(TreatConfiguration)
            //    .BuildSessionFactory();
        }

        static void TreatConfiguration(Configuration configuration)
        {
            var update = new SchemaUpdate(configuration);
            update.Execute(false, true);
        }
    }
}
