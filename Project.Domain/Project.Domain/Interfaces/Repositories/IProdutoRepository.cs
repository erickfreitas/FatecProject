using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        new Produto Add(Produto produto);

        IEnumerable<Produto> GetByUsuario(string usuarioId);
    }
}
