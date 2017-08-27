using System;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class TrocaAppService : AppServiceBase<Troca>, ITrocaAppService
    {
        private readonly ITrocaService _trocaService;

        public TrocaAppService(ITrocaService trocaService)
            :base(trocaService)
        {
            _trocaService = trocaService;
        }

        public TrocaViewModel Add(TrocaViewModel trocaViewModel)
        {
            var trocaAdicionada = _trocaService.Add(Mapper.Map <TrocaViewModel, Troca>(trocaViewModel));
            return Mapper.Map<Troca, TrocaViewModel>(trocaAdicionada);

        }

        public void Update(TrocaViewModel trocaViewModel)
        {
            _trocaService.Update(Mapper.Map<TrocaViewModel, Troca>(trocaViewModel));
        }
    }
}
