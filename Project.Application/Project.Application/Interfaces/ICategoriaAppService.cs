using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface ICategoriaAppService : IAppServiceBase<Categoria>
    {
        void Add(CategoriaViewModel categoriaViewModel);

        IEnumerable<CategoriaViewModel> GetAll();

        CategoriaViewModel GetById(int categoriaId);

        void Remove(CategoriaViewModel categoriaViewModel);

        void Update(CategoriaViewModel categoriaViewModel);

        IEnumerable<CategoriaViewModel> GetCategoriasAtivas();
    }
}
