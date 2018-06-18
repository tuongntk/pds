using System;
using System.Reflection;
using FirstNews.Core.Auditing;
using FirstNews.Core.Authorization;
using FirstNews.Core.Configuration.Startup;
using FirstNews.Core.IoC;
using FirstNews.Core.IoC.Installers;
using FirstNews.Core.Domain.Uow;
using FirstNews.Core.EntityHistory;
using FirstNews.Core.Modules;
using FirstNews.Core.PlugIns;
using FirstNews.Core.Runtime.Validation.Interception;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using JetBrains.Annotations;
using FirstNews.Core.Utils;
using FirstNews.Core;

namespace Abp
{
    /// <summary>
    /// This is the main class that is responsible to start entire ABP system.
    /// Prepares dependency injection and registers core components needed for startup.
    /// It must be instantiated and initialized (see <see cref="Initialize"/>) first in an application.
    /// </summary>
    public class FirstNewsBootstrapper : IDisposable
    {
        /// <summary>
        /// Get the startup module of the application which depends on other used modules.
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>
        /// A list of plug in folders.
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        /// <summary>
        /// Gets IIocManager object used by this class.
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        private FirstNewsModuleManager _moduleManager;
        private ILogger _logger;

        /// <summary>
        /// Creates a new <see cref="FirstNewsBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AbpModule"/>.</param>
        /// <param name="optionsAction">An action to set options</param>
        private FirstNewsBootstrapper([NotNull] Type startupModule, [CanBeNull] Action<FirstNewsBootstrapperOptions> optionsAction = null)
        {
            Check.NotNull(startupModule, nameof(startupModule));

            var options = new FirstNewsBootstrapperOptions();
            optionsAction?.Invoke(options);

            if (!typeof(FirstNewsModule).GetTypeInfo().IsAssignableFrom(startupModule))
            {
                throw new ArgumentException($"{nameof(startupModule)} should be derived from {nameof(FirstNewsModule)}.");
            }

            StartupModule = startupModule;

            IocManager = options.IocManager;
            PlugInSources = options.PlugInSources;

            _logger = NullLogger.Instance;

            if (!options.DisableAllInterceptors)
            {
                AddInterceptorRegistrars();
            }
        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsBootstrapper"/> instance.
        /// </summary>
        /// <typeparam name="TStartupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AbpModule"/>.</typeparam>
        /// <param name="optionsAction">An action to set options</param>
        public static FirstNewsBootstrapper Create<TStartupModule>([CanBeNull] Action<FirstNewsBootstrapperOptions> optionsAction = null)
            where TStartupModule : FirstNewsModule
        {
            return new FirstNewsBootstrapper(typeof(TStartupModule), optionsAction);
        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AbpModule"/>.</param>
        /// <param name="optionsAction">An action to set options</param>
        public static FirstNewsBootstrapper Create([NotNull] Type startupModule, [CanBeNull] Action<FirstNewsBootstrapperOptions> optionsAction = null)
        {
            return new FirstNewsBootstrapper(startupModule, optionsAction);
        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsBootstrapper"/> instance.
        /// </summary>
        /// <typeparam name="TStartupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AbpModule"/>.</typeparam>
        /// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        [Obsolete("Use overload with parameter type: Action<AbpBootstrapperOptions> optionsAction")]
        public static FirstNewsBootstrapper Create<TStartupModule>([NotNull] IIocManager iocManager)
            where TStartupModule : FirstNewsModule
        {
            return new FirstNewsBootstrapper(typeof(TStartupModule), options =>
            {
                options.IocManager = iocManager;
            });
        }

        /// <summary>
        /// Creates a new <see cref="FirstNewsBootstrapper"/> instance.
        /// </summary>
        /// <param name="startupModule">Startup module of the application which depends on other used modules. Should be derived from <see cref="AbpModule"/>.</param>
        /// <param name="iocManager">IIocManager that is used to bootstrap the ABP system</param>
        [Obsolete("Use overload with parameter type: Action<AbpBootstrapperOptions> optionsAction")]
        public static FirstNewsBootstrapper Create([NotNull] Type startupModule, [NotNull] IIocManager iocManager)
        {
            return new FirstNewsBootstrapper(startupModule, options =>
            {
                options.IocManager = iocManager;
            });
        }

        private void AddInterceptorRegistrars()
        {
            ValidationInterceptorRegistrar.Initialize(IocManager);
            AuditingInterceptorRegistrar.Initialize(IocManager);
            EntityHistoryInterceptorRegistrar.Initialize(IocManager);
            UnitOfWorkRegistrar.Initialize(IocManager);
            AuthorizationInterceptorRegistrar.Initialize(IocManager);
        }

        /// <summary>
        /// Initializes the ABP system.
        /// </summary>
        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                RegisterBootstrapper();
                IocManager.IocContainer.Install(new CoreInstaller());

                IocManager.Resolve<AbpPlugInManager>().PlugInSources.AddRange(PlugInSources);
                IocManager.Resolve<StartupConfiguration>().Initialize();

                _moduleManager = IocManager.Resolve<FirstNewsModuleManager>();
                _moduleManager.Initialize(StartupModule);
                _moduleManager.StartModules();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(FirstNewsBootstrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<FirstNewsBootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<FirstNewsBootstrapper>().Instance(this)
                    );
            }
        }

        /// <summary>
        /// Disposes the ABP system.
        /// </summary>
        public virtual void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            _moduleManager?.ShutdownModules();
        }
    }
}
