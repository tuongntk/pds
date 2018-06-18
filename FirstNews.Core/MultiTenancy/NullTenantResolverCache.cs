namespace FirstNews.Core.MultiTenancy
{
    public class NullTenantResolverCache : ITenantResolverCache
    {
        public TenantResolverCacheItem Value
        {
            get { return null; }
            set {  }
        }
    }
}