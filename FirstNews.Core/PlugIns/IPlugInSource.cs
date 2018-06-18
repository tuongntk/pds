using System;
using System.Collections.Generic;
using System.Reflection;

namespace FirstNews.Core.PlugIns
{
    public interface IPlugInSource
    {
        List<Assembly> GetAssemblies();

        List<Type> GetModules();
    }
}