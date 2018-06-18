namespace FirstNews.Core.MultiTenancy
{
    public interface ITenantResolver
    {
        int? ResolveTenantId();
    }
}