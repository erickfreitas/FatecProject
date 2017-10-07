using Project.Application.ViewModels;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        ProdutoViewModel Add(ProdutoViewModel produtoViewModel);

        IEnumerable<ProdutoViewModel> GetAll();

        ProdutoViewModel GetById(int produtoId);

        void Remove(Produto produtoViewModel);

        void Update(ProdutoViewModel produtoViewModel);

        IEnumerable<ProdutoViewModel> GetByUsuario(string usuarioId);


        IQueryable<Produto> GetByFilter(Expression<Func<Produto, bool>> filter);
    }
}
