using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using FirstNews.Core.Utils;

namespace FirstNews.Core.Modules
{
    /// <summary>
    /// Used to store all needed information for a module.
    /// </summary>
    public class FirstNewsModuleInfo
    {
        /// <summary>
        /// The assembly which contains the module definition.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// Type of the module.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Instance of the module.
        /// </summary>
        public FirstNewsModule Instance { get; }

        /// <summary>
        /// Is this module loaded as a plugin.
        /// </summary>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// All dependent modules of this module.
        /// </summary>
        public List<FirstNewsModuleInfo> Dependencies { get; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        public FirstNewsModuleInfo([NotNull] Type type, [NotNull] FirstNewsModule instance, bool isLoadedAsPlugIn)
        {
            Check.NotNull(type, nameof(type));
            Check.NotNull(instance, nameof(instance));

            Type = type;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;
            Assembly = Type.GetTypeInfo().Assembly;

            Dependencies = new List<FirstNewsModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ??
                   Type.FullName;
        }
    }
}