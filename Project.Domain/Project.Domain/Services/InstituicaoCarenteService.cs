using System;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class InstituicaoCarenteService : ServiceBase<InstituicaoCarente>, IInstituicaoCarenteService
    {
        private readonly IInstituicaoCarenteRepository _instituicaoCarenteRepository;

        public InstituicaoCarenteService(IInstituicaoCarenteRepository instituicaoCarenteRepository)
            :base(instituicaoCarenteRepository)
        {
            _instituicaoCarenteRepository = instituicaoCarenteRepository;
        }

        public InstituicaoCarente GetById(string id)
        {
            return _instituicaoCarenteRepository.GetById(id);
        }
    }
}
