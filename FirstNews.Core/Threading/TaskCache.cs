using System.Threading.Tasks;

namespace FirstNews.Core.Threading
{
    public static class AbpTaskCache
    {
        public static Task CompletedTask { get; } = Task.FromResult(0);
    }
}
