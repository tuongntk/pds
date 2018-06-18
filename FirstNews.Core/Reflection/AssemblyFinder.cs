﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FirstNews.Core.Modules;

namespace FirstNews.Core.Reflection
{
    public class AssemblyFinder : IAssemblyFinder
    {
        private readonly IFirstNewsModuleManager _moduleManager;

        public AssemblyFinder(IFirstNewsModuleManager moduleManager)
        {
            _moduleManager = moduleManager;
        }

        public List<Assembly> GetAllAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var module in _moduleManager.Modules)
            {
                assemblies.Add(module.Assembly);
                assemblies.AddRange(module.Instance.GetAdditionalAssemblies());
            }

            return assemblies.Distinct().ToList();
        }
    }
}