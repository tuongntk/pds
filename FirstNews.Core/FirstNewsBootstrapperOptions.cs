using FirstNews.Core.IoC;
using FirstNews.Core.PlugIns;

namespace FirstNews.Core
{
    public class FirstNewsBootstrapperOptions
    {
        /// <summary>
        /// Used to disable all interceptors added by ABP.
        /// </summary>
        public bool DisableAllInterceptors { get; set; }

        /// <summary>
        /// IIocManager that is used to bootstrap the ABP system. If set to null, uses global <see cref="Abp.Dependency.IocManager.Instance"/>
        /// </summary>
        public IIocManager IocManager { get; set; }

        /// <summary>
        /// List of plugin sources.
        /// </summary>
        public PlugInSourceList PlugInSources { get; }

        public FirstNewsBootstrapperOptions()
        {
            IocManager = IoC.IocManager.Instance;
            PlugInSources = new PlugInSourceList();
        }
    }
}
