using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class RespostaService : ServiceBase<Resposta>, IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;

        public RespostaService(IRespostaRepository respostaRepository )
            :base(respostaRepository)
        {
            _respostaRepository = respostaRepository;
        }


        Resposta IRespostaService.Add(Resposta pergunta)
        {
            return _respostaRepository.Add(pergunta);
        }
    }
}
