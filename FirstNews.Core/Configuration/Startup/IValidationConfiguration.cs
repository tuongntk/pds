using System;
using System.Collections.Generic;
using FirstNews.Core.Collections;
using FirstNews.Core.Runtime.Validation.Interception;

namespace FirstNews.Core.Configuration.Startup
{
    public interface IValidationConfiguration
    {
        List<Type> IgnoredTypes { get; }

        /// <summary>
        /// A list of method parameter validators.
        /// </summary>
        ITypeList<IMethodParameterValidator> Validators { get; }
    }
}