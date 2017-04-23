using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class SubCategoriaService : ServiceBase<SubCategoria>, ISubCategoriaService
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;
        public SubCategoriaService(ISubCategoriaRepository subCategoriaRepository)
            : base(subCategoriaRepository)
        {
            _subCategoriaRepository = subCategoriaRepository;
        }

        public IEnumerable<SubCategoria> GetByCategoria(int categoriaId)
        {
            return _subCategoriaRepository.GetByCategoria(categoriaId);
        }
    }
}
