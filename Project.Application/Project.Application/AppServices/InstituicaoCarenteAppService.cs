using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class InstituicaoCarenteAppService : AppServiceBase<InstituicaoCarente>, IInstituicaoCarenteAppService
    {
        private readonly IInstituicaoCarenteService _instituicaoCarenteService;

        public InstituicaoCarenteAppService(IInstituicaoCarenteService instituicaoCarenteService)
            :base(instituicaoCarenteService)
        {
            _instituicaoCarenteService = instituicaoCarenteService;
        }

        public IEnumerable<InstituicaoCarenteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<InstituicaoCarente>, IEnumerable<InstituicaoCarenteViewModel>>(_instituicaoCarenteService.GetAll());
        }
    }
}
