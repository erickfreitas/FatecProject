using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        new Produto Add(Produto produto);
    }
}
