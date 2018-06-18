using System.Collections.Generic;

namespace FirstNews.Core.Localization
{
    public interface ILanguageProvider
    {
        IReadOnlyList<LanguageInfo> GetLanguages();
    }
}