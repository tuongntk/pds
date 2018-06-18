using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace FirstNews.Core.Authorization
{
    public interface IAuthorizationHelper
    {
        Task AuthorizeAsync(IEnumerable<IAbpAuthorizeAttribute> authorizeAttributes);

        Task AuthorizeAsync(MethodInfo methodInfo, Type type);
    }
}