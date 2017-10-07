using System;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;

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

        public IQueryable<Troca> GetByFilter(Expression<Func<Troca, bool>> filter)
        {
           return _trocaService.GetByFilter(filter);
            
        }

        public TrocaViewModel GetById(int trocaId)
        {
            return Mapper.Map<Troca, TrocaViewModel>(_trocaService.GetById(trocaId));
        }

        public void Update(TrocaViewModel trocaViewModel)
        {
            _trocaService.Update(Mapper.Map<TrocaViewModel, Troca>(trocaViewModel));
        }

        public void Remove(Troca trocaViewModel)
        {
            _trocaService.Remove(trocaViewModel);
        }
    }
}
