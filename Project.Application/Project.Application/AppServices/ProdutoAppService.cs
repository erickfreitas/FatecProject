using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

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
            _produtoService.Add(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
        }

        public IEnumerable<ProdutoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoService.GetAll());
        }

        public ProdutoViewModel GetById(int produtoId)
        {
            return Mapper.Map<Produto, ProdutoViewModel>(_produtoService.GetById(produtoId));
        }

        public void Remove(ProdutoViewModel produtoViewModel)
        {
            _produtoService.Remove(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
        }

        public void Update(ProdutoViewModel produtoViewModel)
        {
            _produtoService.Update(Mapper.Map<ProdutoViewModel, Produto>(produtoViewModel));
        }
    }
}
