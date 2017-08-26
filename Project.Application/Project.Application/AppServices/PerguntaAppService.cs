using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

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

        public PerguntaUsuarioViewModel Add(PerguntaViewModel perguntaViewModel)
        {
            var perguntaAdicionada = _perguntaService.Add(Mapper.Map<PerguntaViewModel, Pergunta>(perguntaViewModel));
            return Mapper.Map<Pergunta, PerguntaUsuarioViewModel>(perguntaAdicionada);
        }

        public IEnumerable<PerguntaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Pergunta>, IEnumerable<PerguntaViewModel>>(_perguntaService.GetAll());
        }

        public PerguntaViewModel GetById(int perguntaId)
        {
            return Mapper.Map<Pergunta, PerguntaViewModel>(_perguntaService.GetById(perguntaId));
        }

        public IEnumerable<PerguntaUsuarioViewModel> GetByProduto(int produtoId)
        {
            return Mapper.Map<IEnumerable<Pergunta>, IEnumerable<PerguntaUsuarioViewModel>>(_perguntaService.GetByProduto(produtoId));
        }

        public IEnumerable<PerguntaViewModel> GetByUsuario(string usuarioId)
        {
            return Mapper.Map<IEnumerable<Pergunta>, IEnumerable<PerguntaViewModel>>(_perguntaService.GetByUsuario(usuarioId));
        }

        public PerguntaUsuarioViewModel GetPerguntaUsuarioById(int perguntaId)
        {
            return Mapper.Map<Pergunta, PerguntaUsuarioViewModel>(_perguntaService.GetById(perguntaId));
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
