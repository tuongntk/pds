using System.Collections.Generic;

namespace FirstNews.Core.EntityHistory
{
    internal class EntityHistorySelectorList : List<NamedTypeSelector>, IEntityHistorySelectorList
    {
        public bool RemoveByName(string name)
        {
            return RemoveAll(s => s.Name == name) > 0;
        }
    }
}
