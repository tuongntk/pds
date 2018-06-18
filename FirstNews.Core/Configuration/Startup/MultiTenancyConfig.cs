using FirstNews.Core.Collections;
using FirstNews.Core.MultiTenancy;

namespace FirstNews.Core.Configuration.Startup
{
    internal class MultiTenancyConfig : IMultiTenancyConfig
    {
        // Is multi-tenancy enabled?
        // Default value: false.
        public bool IsEnabled { get; set; }

        public ITypeList<ITenantResolveContributor> Resolvers { get; }

        public MultiTenancyConfig()
        {
            Resolvers = new TypeList<ITenantResolveContributor>();
        }
    }
}