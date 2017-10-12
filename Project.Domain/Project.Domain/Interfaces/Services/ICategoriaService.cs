using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface ICategoriaService : IServiceBase<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasAtivas();
        bool PossuiProduto(int categoriaId);
    }
}
