using System.Threading.Tasks;
using FirstNews.Core.IoC;

namespace FirstNews.Core.Configuration
{
    public interface ISettingClientVisibilityProvider
    {
        Task<bool> CheckVisible(IScopedIocResolver scope);
    }
}