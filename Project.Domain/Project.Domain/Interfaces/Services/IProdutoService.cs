using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        new Produto Add(Produto produto);
        IEnumerable<Produto> GetByUsuario(string usuarioId);
    }
}
