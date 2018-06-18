using System;
using System.Collections.Generic;

namespace FirstNews.Core.Modules
{
    public interface IAbpModuleManager
    {
        AbpModuleInfo StartupModule { get; }

        IReadOnlyList<AbpModuleInfo> Modules { get; }

        void Initialize(Type startupModule);

        void StartModules();

        void ShutdownModules();
    }
}