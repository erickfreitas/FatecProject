using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;

namespace Project.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
    }
}
