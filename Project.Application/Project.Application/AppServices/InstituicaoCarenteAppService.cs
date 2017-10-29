using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

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

        public void Add(RegistrarInstituiçãoCarenteViewModel viewModel, string userId)
        {
            var instituicaoCarente = Mapper.Map<RegistrarInstituiçãoCarenteViewModel, InstituicaoCarente>(viewModel);
            instituicaoCarente.InstituicaoCarenteId = userId;
            _instituicaoCarenteService.Add(instituicaoCarente);
        }

        public IEnumerable<InstituicaoCarenteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<InstituicaoCarente>, IEnumerable<InstituicaoCarenteViewModel>>(_instituicaoCarenteService.GetAll());
        }

        public InstituicaoCarenteViewModel GetById(string id)
        {
            return Mapper.Map<InstituicaoCarente, InstituicaoCarenteViewModel>(_instituicaoCarenteService.GetById(id));
        }
    }
}
