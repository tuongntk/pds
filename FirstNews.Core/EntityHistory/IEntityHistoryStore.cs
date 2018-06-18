﻿using System.Threading.Tasks;

namespace FirstNews.Core.EntityHistory
{
    /// <summary>
    /// This interface should be implemented by vendors to
    /// make entity history working.
    /// </summary>
    public interface IEntityHistoryStore
    {
        /// <summary>
        /// Should save entity change set to a persistent store.
        /// </summary>
        /// <param name="entityChangeSet">Entity change set</param>
        Task SaveAsync(EntityChangeSet entityChangeSet);
    }
}
