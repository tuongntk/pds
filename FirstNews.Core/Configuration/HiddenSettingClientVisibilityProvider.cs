using System.Threading.Tasks;
using FirstNews.Core.IoC;

namespace FirstNews.Core.Configuration
{
    public class HiddenSettingClientVisibilityProvider : ISettingClientVisibilityProvider
    {
        public async Task<bool> CheckVisible(IScopedIocResolver scope)
        {
            return await Task.FromResult(false);
        }
    }
}