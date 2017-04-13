using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class SubCategoriaAppService : AppServiceBase<SubCategoria>, ISubCategoriaAppService
    {
        private readonly ISubCategoriaService _subCategoriaService;

        public SubCategoriaAppService(ISubCategoriaService subCategoriaService)
            :base(subCategoriaService)
        {
            _subCategoriaService = subCategoriaService;
        }

        public void Add(SubCategoriaViewModel subCategoriaViewModel)
        {
            _subCategoriaService.Add(Mapper.Map<SubCategoriaViewModel, SubCategoria>(subCategoriaViewModel));
        }

        public IEnumerable<SubCategoriaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<SubCategoria>, IEnumerable<SubCategoriaViewModel>>(_subCategoriaService.GetAll());
        }

        public SubCategoriaViewModel GetById(int subCategoriaId)
        {
            return Mapper.Map<SubCategoria, SubCategoriaViewModel>(_subCategoriaService.GetById(subCategoriaId));
        }

        public void Remove(SubCategoriaViewModel subCategoriaViewModel)
        {
            _subCategoriaService.Remove(Mapper.Map<SubCategoriaViewModel, SubCategoria>(subCategoriaViewModel));
        }

        public void Update(SubCategoriaViewModel subCategoriaViewModel)
        {
            _subCategoriaService.Update(Mapper.Map<SubCategoriaViewModel, SubCategoria>(subCategoriaViewModel));
        }
    }
}
