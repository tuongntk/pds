using FirstNews.Core.IoC;
using FirstNews.Core.Domain.Repositories;

namespace FirstNews.Core.Orm
{
    public interface ISecondaryOrmRegistrar
    {
        string OrmContextKey { get; }

        void RegisterRepositories(IIocManager iocManager, AutoRepositoryTypesAttribute defaultRepositoryTypes);
    }
}
