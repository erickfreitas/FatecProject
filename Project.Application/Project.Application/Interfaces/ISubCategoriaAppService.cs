using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface ISubCategoriaAppService : IAppServiceBase<SubCategoria>
    {
        void Add(SubCategoriaViewModel subCategoriaViewModel);

        IEnumerable<SubCategoriaViewModel> GetAll();

        SubCategoriaViewModel GetById(int subCategoriaId);

        void Remove(SubCategoriaViewModel subCategoriaViewModel);

        void Update(SubCategoriaViewModel subCategoriaViewModel);

        IEnumerable<SubCategoriaViewModel> GetByCategoria(int categoriaId);

        bool PossuiProduto(int subCategoriaId);
    }
}
