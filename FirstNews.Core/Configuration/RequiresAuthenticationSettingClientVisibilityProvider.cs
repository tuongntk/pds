using System.Threading.Tasks;
using FirstNews.Core.IoC;
using FirstNews.Core.Runtime.Session;

namespace FirstNews.Core.Configuration
{
    public class RequiresAuthenticationSettingClientVisibilityProvider : ISettingClientVisibilityProvider
    {
        public async Task<bool> CheckVisible(IScopedIocResolver scope)
        {
            return await Task.FromResult(
                scope.Resolve<ISession>().UserId.HasValue
            );
        }
    }
}