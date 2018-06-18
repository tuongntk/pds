using System;
using System.Collections.Generic;

namespace FirstNews.Core.Modules
{
    public interface IFirstNewsModuleManager
    {
        FirstNewsModuleInfo StartupModule { get; }

        IReadOnlyList<FirstNewsModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}