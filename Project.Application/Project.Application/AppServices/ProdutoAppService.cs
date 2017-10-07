using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace Project.Application.AppServices
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;

        public ProdutoAppService(IProdutoService produtoService)
            :base(produtoService)
        {
            _produtoService = produtoService;
        }

        public ProdutoViewModel Add(ProdutoViewModel produtoViewModel)
        {
            var produtoAdicionado = _produtoService.Add(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
            return Mapper.Map<Produto, ProdutoViewModel>(produtoAdicionado);
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoService.GetAll());
        }

        public ProdutoViewModel GetById(int produtoId)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_produtoService.GetById(produtoId));
        }

        public IEnumerable<ProdutoViewModel> GetByUsuario(string usuarioId)
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoService.GetByUsuario(usuarioId));
        }

        public void Remove(ProdutoViewModel produtoViewModel)
        {
            _produtoService.Remove(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            _produtoService.Update(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
        }


        public IQueryable<Produto> GetByFilter(Expression<Func<Produto, bool>> filter)
        {
            return _produtoService.GetByFilter(filter);

        }
    }
}
