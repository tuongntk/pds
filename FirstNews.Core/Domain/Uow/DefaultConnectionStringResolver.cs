using System.Configuration;
using FirstNews.Core.Configuration.Startup;
using FirstNews.Core.IoC;
using FirstNews.Core.Utils;

namespace FirstNews.Core.Domain.Uow
{
    /// <summary>
    /// Default implementation of <see cref="IConnectionStringResolver"/>.
    /// Get connection string from <see cref="IAbpStartupConfiguration"/>,
    /// or "Default" connection string in config file,
    /// or single connection string in config file.
    /// </summary>
    public class DefaultConnectionStringResolver : IConnectionStringResolver, ITransientDependency
    {
        private readonly IStartupConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultConnectionStringResolver"/> class.
        /// </summary>
        public DefaultConnectionStringResolver(IStartupConfiguration configuration)
        {
            _configuration = configuration;
        }

        public virtual string GetNameOrConnectionString(ConnectionStringResolveArgs args)
        {
            Check.NotNull(args, nameof(args));

            var defaultConnectionString = _configuration.DefaultNameOrConnectionString;
            if (!string.IsNullOrWhiteSpace(defaultConnectionString))
            {
                return defaultConnectionString;
            }

            if (ConfigurationManager.ConnectionStrings["Default"] != null)
            {
                return "Default";
            }

            if (ConfigurationManager.ConnectionStrings.Count == 1)
            {
                return ConfigurationManager.ConnectionStrings[0].ConnectionString;
            }

            throw new FirstNewsException("Could not find a connection string definition for the application. Set IAbpStartupConfiguration.DefaultNameOrConnectionString or add a 'Default' connection string to application .config file.");
        }
    }
}