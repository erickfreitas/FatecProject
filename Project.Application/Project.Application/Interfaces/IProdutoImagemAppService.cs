using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IProdutoImagemAppService : IAppServiceBase<ProdutoImagem>
    {
        void Add(ProdutoImagemViewModel produtoImagemViewModel);

        IEnumerable<ProdutoImagemViewModel> GetAll();

        ProdutoImagemViewModel GetById(int produtoImagemId);

        void Remove(ProdutoImagemViewModel produtoImagemViewModel);

        void Update(ProdutoImagemViewModel produtoImagemViewModel);
    }
}
