using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        ProdutoViewModel Add(ProdutoViewModel produtoViewModel);

        IEnumerable<ProdutoViewModel> GetAll();

        ProdutoViewModel GetById(int produtoId);

        void Remove(ProdutoViewModel produtoViewModel);

        void Update(ProdutoViewModel produtoViewModel);

        IEnumerable<ProdutoViewModel> GetByUsuario(string usuarioId);
    }
}
