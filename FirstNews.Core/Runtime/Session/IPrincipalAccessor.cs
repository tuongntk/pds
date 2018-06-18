using System.Security.Claims;

namespace FirstNews.Core.Runtime.Session
{
    public interface IPrincipalAccessor
    {
        ClaimsPrincipal Principal { get; }
    }
}
