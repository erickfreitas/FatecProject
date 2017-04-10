using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;

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

        public void Add(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel GetById(int produtoId)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
