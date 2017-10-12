using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface ISubCategoriaRepository : IRepositoryBase<SubCategoria>
    {
        IEnumerable<SubCategoria> GetByCategoria(int categoriaId);
        bool PossuiProduto(int subCategoriaId);
    }
}
