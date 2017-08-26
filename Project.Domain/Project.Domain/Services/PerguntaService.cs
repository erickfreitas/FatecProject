using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace Project.Domain.Services
{
    public class PerguntaService : ServiceBase<Pergunta>, IPerguntaService
    {
        private readonly IPerguntaRepository _perguntaRepository;

        public PerguntaService(IPerguntaRepository perguntaRepository)
            :base(perguntaRepository)
        {
            _perguntaRepository = perguntaRepository;

        }

        public IEnumerable<Pergunta> GetByUsuario(string usuarioId)
        {
            return _perguntaRepository.GetByUsuario(usuarioId);
        }

        public new Pergunta Add(Pergunta pergunta)
        {
            return _perguntaRepository.Add(pergunta);
        }

        public IEnumerable<Pergunta> GetByProduto(int produtoId)
        {
            return _perguntaRepository.GetByProduto(produtoId);
        }
    }
}
