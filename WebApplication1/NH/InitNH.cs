﻿using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace WebApplication1.NH
{
    public class InitNH
    {
        public static ISessionFactory SessionFactory;
        public void InitNHibernate()
        {
            if (SessionFactory != null)
                return;

            string connectionString = @"Server = 172.21.70.40; Database = PraktykiWorkFlow; User Id = sa;Password = cdnxl1*";



            NHibernate.Cfg.Configuration config = new NHibernate.Cfg.Configuration().DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.ConnectionString = connectionString;
            });
            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(new List<Type>()
            {
              typeof(MapUser),
              typeof(MapAttribute),
              typeof(MapDocument),
              typeof(MapFlowDefinition),
              typeof(MapListElement),
              typeof(MapPosition),
              typeof(MapStep),
              typeof(MapAccess),
              typeof(MapFlow),
              typeof(MapFlowExtension),
              typeof(MapTask)

            });

          config.AddDeserializedMapping(mapper.CompileMappingForAllExplicitlyAddedEntities(), null);

            NHibernate.Tool.hbm2ddl.SchemaMetadataUpdater.QuoteTableAndColumns(config);

            SessionFactory = config.BuildSessionFactory();
        }

        public static ISession OppenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}