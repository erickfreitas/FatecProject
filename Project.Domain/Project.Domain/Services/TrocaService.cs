using System;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class TrocaService : ServiceBase<Troca>, ITrocaService

    {
        private readonly ITrocaRepository _trocaRepository;

        public TrocaService(ITrocaRepository trocaRepository)
            :base(trocaRepository)
        {
            _trocaRepository = trocaRepository;
        }

        public new Troca Add(Troca troca)
        {
            return _trocaRepository.Add(troca);
        }
    }
}
