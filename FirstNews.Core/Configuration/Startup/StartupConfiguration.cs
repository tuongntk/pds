using System;
using System.Collections.Generic;
using System.Linq;
using FirstNews.Core.Application.Features;
using FirstNews.Core.Auditing;
using FirstNews.Core.BackgroundJobs;
using FirstNews.Core.EntityHistory;
using FirstNews.Core.Notifications;
using FirstNews.Core.Resources.Embedded;
using FirstNews.Core.Runtime.Caching.Configuration;
using FirstNews.Core.IoC;
using FirstNews.Core.Domain.Uow;

namespace FirstNews.Core.Configuration.Startup
{
    internal class StartupConfiguration : DictionaryBasedConfig, IStartupConfiguration
    {
        public IIocManager IocManager { get; }

        public ILocalizationConfiguration Localization { get; private set; }

        public IAuthorizationConfiguration Authorization { get; private set; }

        public IValidationConfiguration Validation { get; private set; }

        public ISettingsConfiguration Settings { get; private set; }

        // Gets/sets default connection string used by ORM module.
        // It can be name of a connection string in application's config file or can be full connection string.
        public string DefaultNameOrConnectionString { get; set; }

        public IModuleConfigurations Modules { get; private set; }

        public IUnitOfWorkDefaultOptions UnitOfWork { get; private set; }

        public IFeatureConfiguration Features { get; private set; }

        public IBackgroundJobConfiguration BackgroundJobs { get; private set; }

        public INotificationConfiguration Notifications { get; private set; }

        public INavigationConfiguration Navigation { get; private set; }

        public IEventBusConfiguration EventBus { get; private set; }

        public IAuditingConfiguration Auditing { get; private set; }

        public ICachingConfiguration Caching { get; private set; }

        public IMultiTenancyConfig MultiTenancy { get; private set; }

        public Dictionary<Type, Action> ServiceReplaceActions { get; private set; }

        public IEmbeddedResourcesConfiguration EmbeddedResources { get; private set; }

        public IEntityHistoryConfiguration EntityHistory { get; private set; }

        public IList<ICustomConfigProvider> CustomConfigProviders { get; private set; }

        public Dictionary<string, object> GetCustomConfig()
        {
            var customConfig = new Dictionary<string, object>();

            using (var scope = IocManager.CreateScope())
            {
                foreach (var provider in CustomConfigProviders)
                {
                    customConfig = customConfig
                        .Concat(provider.GetConfig(new CustomConfigProviderContext(scope)))
                        .ToDictionary(key => key.Key, value => value.Value);
                }
            }

            return customConfig;
        }

        public StartupConfiguration(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        public void Initialize()
        {
            Localization = IocManager.Resolve<ILocalizationConfiguration>();
            Modules = IocManager.Resolve<IModuleConfigurations>();
            Features = IocManager.Resolve<IFeatureConfiguration>();
            Navigation = IocManager.Resolve<INavigationConfiguration>();
            Authorization = IocManager.Resolve<IAuthorizationConfiguration>();
            Validation = IocManager.Resolve<IValidationConfiguration>();
            Settings = IocManager.Resolve<ISettingsConfiguration>();
            UnitOfWork = IocManager.Resolve<IUnitOfWorkDefaultOptions>();
            EventBus = IocManager.Resolve<IEventBusConfiguration>();
            MultiTenancy = IocManager.Resolve<IMultiTenancyConfig>();
            Auditing = IocManager.Resolve<IAuditingConfiguration>();
            Caching = IocManager.Resolve<ICachingConfiguration>();
            BackgroundJobs = IocManager.Resolve<IBackgroundJobConfiguration>();
            Notifications = IocManager.Resolve<INotificationConfiguration>();
            EmbeddedResources = IocManager.Resolve<IEmbeddedResourcesConfiguration>();
            EntityHistory = IocManager.Resolve<IEntityHistoryConfiguration>();

            CustomConfigProviders = new List<ICustomConfigProvider>();
            ServiceReplaceActions = new Dictionary<Type, Action>();
        }

        public void ReplaceService(Type type, Action replaceAction)
        {
            ServiceReplaceActions[type] = replaceAction;
        }

        public T Get<T>()
        {
            return GetOrCreate(typeof(T).FullName, () => IocManager.Resolve<T>());
        }
    }
}