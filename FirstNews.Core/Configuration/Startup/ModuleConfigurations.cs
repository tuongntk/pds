namespace FirstNews.Core.Configuration.Startup
{
    internal class ModuleConfigurations : IModuleConfigurations
    {
        public IStartupConfiguration AbpConfiguration { get; private set; }

        public ModuleConfigurations(IStartupConfiguration abpConfiguration)
        {
            AbpConfiguration = abpConfiguration;
        }
    }
}