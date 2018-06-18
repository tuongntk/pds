using JetBrains.Annotations;

namespace FirstNews.Core.MultiTenancy
{
    public interface ITenantResolverCache
    {
        [CanBeNull]
        TenantResolverCacheItem Value { get; set; }
    }
}