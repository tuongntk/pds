using System;
using System.Collections.Generic;
using FirstNews.Core.Collections;
using FirstNews.Core.Runtime.Validation.Interception;
using FirstNews.Core.Collections;

namespace FirstNews.Core.Configuration.Startup
{
    public class ValidationConfiguration : IValidationConfiguration
    {
        public List<Type> IgnoredTypes { get; }

        public ITypeList<IMethodParameterValidator> Validators { get; }

        public ValidationConfiguration()
        {
            IgnoredTypes = new List<Type>();
            Validators = new TypeList<IMethodParameterValidator>();
        }
    }
}