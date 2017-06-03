using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class RespostaAppService : AppServiceBase<Resposta>, IRespostaAppService
    {
        private readonly IRespostaService _respostaService;

        public RespostaAppService(IRespostaService respostaService)
            :base(respostaService)
        {
            _respostaService = respostaService;
        }

        public RespostaViewModel Add(RespostaViewModel respostaViewModel)
        {
            var respostaAdicionada = _respostaService.Add(Mapper.Map<RespostaViewModel, Resposta>(respostaViewModel));
            return Mapper.Map<Resposta, RespostaViewModel>(respostaAdicionada);
        }

        public IEnumerable<RespostaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Resposta>, IEnumerable<RespostaViewModel>>(_respostaService.GetAll());
        }

        public RespostaViewModel GetById(int respostaId)
        {
            return Mapper.Map<Resposta, RespostaViewModel>(_respostaService.GetById(respostaId));
        }


        public void Remove(RespostaViewModel respostaViewModel)
        {
            _respostaService.Remove(Mapper.Map<RespostaViewModel, Resposta>(respostaViewModel));
        }

        public void Update(RespostaViewModel respostaViewModel)
        {
            _respostaService.Update(Mapper.Map<RespostaViewModel, Resposta>(respostaViewModel));
        }
    }
}
