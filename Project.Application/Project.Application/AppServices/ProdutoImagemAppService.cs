using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class ProdutoImagemAppService : AppServiceBase<ProdutoImagem>, IProdutoImagemAppService
    {
        private readonly IProdutoImagemService _produtoImagemService;

        public ProdutoImagemAppService(IProdutoImagemService produtoImagemService)
            : base(produtoImagemService)
        {
            _produtoImagemService = produtoImagemService;
        }

        public void Add(ProdutoImagemViewModel produtoImagemViewModel)
        {
            _produtoImagemService.Add(Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(produtoImagemViewModel));
        }

        public IEnumerable<ProdutoImagemViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ProdutoImagem>, IEnumerable<ProdutoImagemViewModel>>(_produtoImagemService.GetAll());
        }

        public ProdutoImagemViewModel GetById(int produtoImagemId)
        {
            return Mapper.Map<ProdutoImagem, ProdutoImagemViewModel>(_produtoImagemService.GetById(produtoImagemId));
        }

        public void Remove(ProdutoImagemViewModel produtoImagemViewModel)
        {
            _produtoImagemService.Remove(Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(produtoImagemViewModel));
        }

        public void Update(ProdutoImagemViewModel produtoImagemViewModel)
        {
            _produtoImagemService.Update(Mapper.Map<ProdutoImagemViewModel, ProdutoImagem>(produtoImagemViewModel));
        }
    }
}
