using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        IEnumerable<Categoria> GetCategoriasAtivas();
    }
}
