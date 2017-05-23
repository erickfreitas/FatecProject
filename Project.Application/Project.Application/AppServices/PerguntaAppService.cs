using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class PerguntaAppService : AppServiceBase<Pergunta>, IPerguntaAppService
    {
        private readonly IPerguntaService _perguntaService;

        public PerguntaAppService(IPerguntaService perguntaService)
            :base(perguntaService)
        {
            _perguntaService = perguntaService;
        }

        public PerguntaViewModel Add(PerguntaViewModel perguntaViewModel)
        {
            var perguntaAdicionada = _perguntaService.Add(Mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel));
            return Mapper.Map<Pergunta, PerguntaViewModel>(perguntaAdicionada);
        }

        public IEnumerable<PerguntaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pergunta>, IEnumerable<PerguntaViewModel>>(_perguntaService.GetAll());
        }

        public PerguntaViewModel GetById(int perguntaId)
        {
            return Mapper.Map<Pergunta, PerguntaViewModel>(_perguntaService.GetById(perguntaId));
        }

        public IEnumerable<PerguntaViewModel> GetByUsuario(string usuarioId)
        {
            return Mapper.Map<IEnumerable<Pergunta>, IEnumerable<PerguntaViewModel>>(_perguntaService.GetByUsuario(usuarioId));
        }

        public void Remove(PerguntaViewModel perguntaViewModel)
        {
            _perguntaService.Remove(Mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel));
        }

        public void Update(PerguntaViewModel perguntaViewModel)
        {
            _perguntaService.Update(Mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel));
        }
    }
}
