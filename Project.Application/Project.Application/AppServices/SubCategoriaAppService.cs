using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

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

        public IEnumerable<SubCategoriaViewModel> GetByCategoria(int categoriaId)
        {
            return Mapper.Map<IEnumerable<SubCategoria>, IEnumerable<SubCategoriaViewModel>>(_subCategoriaService.GetByCategoria(categoriaId));
        }

        public SubCategoriaViewModel GetById(int subCategoriaId)
        {
            return Mapper.Map<SubCategoria, SubCategoriaViewModel>(_subCategoriaService.GetById(subCategoriaId));
        }

        public bool PossuiProduto(int subCategoriaId)
        {
            return _subCategoriaService.PossuiProduto(subCategoriaId);
        }

        public void Remove(SubCategoriaViewModel subCategoriaViewModel)
        {
            var subCategoria = _subCategoriaService.GetById(subCategoriaViewModel.SubCategoriaId);
            _subCategoriaService.Remove(subCategoria);
        }

        public void Update(SubCategoriaViewModel subCategoriaViewModel)
        {
            _subCategoriaService.Update(Mapper.Map<SubCategoriaViewModel, SubCategoria>(subCategoriaViewModel));
        }
    }
}
