using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface ISubCategoriaService : IServiceBase<SubCategoria>
    {
        IEnumerable<SubCategoria> GetByCategoria(int categoriaId);
    }
}
