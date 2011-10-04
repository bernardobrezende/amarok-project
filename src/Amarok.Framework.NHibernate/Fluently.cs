﻿using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Amarok.Framework.NHibernate
{
    public class Fluently
    {
        #region Properties to control inner state

        private bool createDatabase;
        private static FluentConfiguration currentFluentConfig;
        private static Configuration currentNHConfig;
        private static readonly object syncRoot = new object();

        #endregion

        #region Private constructors

        private Fluently(FluentConfiguration fConfig)
            : this(fConfig, false) { }

        private Fluently(FluentConfiguration fConfig, bool createDb)
            : this(fConfig, new Configuration(), createDb)
        {
        }

        private Fluently(FluentConfiguration fConfig, Configuration nhConfig, bool createDb)
        {
            currentFluentConfig = fConfig;
            currentNHConfig = nhConfig;
            this.createDatabase = createDb;
        }

        #endregion

        #region Fluent Interface

        public static Fluently Using(Assembly asm)
        {
            lock (syncRoot)
            {
                currentFluentConfig = FluentNHibernate.Cfg.Fluently
                   .Configure()
                   .Mappings(m => m.FluentMappings.AddFromAssembly(asm));
                //
                return new Fluently(currentFluentConfig);
            }
        }

        public Fluently AsMappings()
        {
            return new Fluently(currentFluentConfig, currentNHConfig, this.createDatabase);
        }

        public Fluently Create()
        {
            return new Fluently(currentFluentConfig, currentNHConfig, true);
        }

        public Fluently And()
        {
            return new Fluently(currentFluentConfig, currentNHConfig, this.createDatabase);
        }

        public ISessionFactory BuildSessionFactory()
        {
            return currentFluentConfig.BuildSessionFactory();
        }

        public Fluently ConfigureDatabase(IPersistenceConfigurer cfg)
        {
            lock (syncRoot)
            {
                currentFluentConfig.Database(cfg);
                //
                if (this.createDatabase)
                {
                    currentFluentConfig.ExposeConfiguration(c =>
                    {
                        new SchemaExport(c).Execute(false, true, false);
                    });
                }
                //    
                currentNHConfig = currentFluentConfig.BuildConfiguration();
            }
            return new Fluently(currentFluentConfig, currentNHConfig, this.createDatabase);
        }

        #endregion
    }
}