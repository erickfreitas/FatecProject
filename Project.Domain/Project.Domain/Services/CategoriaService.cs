using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace Project.Domain.Services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
            :base(categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IEnumerable<Categoria> GetCategoriasAtivas()
        {
            return _categoriaRepository.GetCategoriasAtivas();
        }

        public bool PossuiProduto(int categoriaId)
        {
            return _categoriaRepository.PossuiProduto(categoriaId);
        }
    }
}
