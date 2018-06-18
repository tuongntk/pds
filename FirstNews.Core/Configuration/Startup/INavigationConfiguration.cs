using FirstNews.Core.Application.Navigation;
using FirstNews.Core.Collections;

namespace FirstNews.Core.Configuration.Startup
{
    /// <summary>
    /// Used to configure navigation.
    /// </summary>
    public interface INavigationConfiguration
    {
        /// <summary>
        /// List of navigation providers.
        /// </summary>
        ITypeList<NavigationProvider> Providers { get; }
    }
}