using FirstNews.Core.Configuration.Startup;

namespace FirstNews.Core.BackgroundJobs
{
    internal class BackgroundJobConfiguration : IBackgroundJobConfiguration
    {
        public bool IsJobExecutionEnabled { get; set; }
        
        public IStartupConfiguration AbpConfiguration { get; private set; }

        public BackgroundJobConfiguration(IStartupConfiguration abpConfiguration)
        {
            AbpConfiguration = abpConfiguration;

            IsJobExecutionEnabled = true;
        }
    }
}