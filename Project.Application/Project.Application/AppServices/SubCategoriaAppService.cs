using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;

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
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategoriaViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public SubCategoriaViewModel GetById(int subCategoriaId)
        {
            throw new NotImplementedException();
        }

        public void Remove(SubCategoriaViewModel subCategoriaViewModel)
        {
            throw new NotImplementedException();
        }

        public void Update(SubCategoriaViewModel subCategoriaViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
