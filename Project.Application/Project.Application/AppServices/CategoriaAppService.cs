using AutoMapper;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using System.Collections.Generic;
using System;

namespace Project.Application.AppServices
{
    public class CategoriaAppService : AppServiceBase<Categoria>, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(ICategoriaService categoriaService)
            :base(categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public void Add(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.Add(Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel));
        }

        public IEnumerable<CategoriaViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaService.GetAll());
        }

        public CategoriaViewModel GetById(int categoriaId)
        {
            return Mapper.Map<Categoria, CategoriaViewModel>(_categoriaService.GetById(categoriaId));
        }

        public IEnumerable<CategoriaViewModel> GetCategoriasAtivas()
        {
            var categorias = new List<CategoriaViewModel>();
            foreach (var currentCategoria in _categoriaService.GetCategoriasAtivas())
            {
                var categoria = Mapper.Map<Categoria, CategoriaViewModel>(currentCategoria);
                foreach (var subCategoria in currentCategoria.SubCategorias)
                {
                    if (subCategoria.MostrarNoMenuInicial)
                    {
                        categoria.SubCategoriaViewModels.Add(Mapper.Map<SubCategoria, SubCategoriaViewModel>(subCategoria));
                    }
                }                
                categorias.Add(categoria);
            }
            return categorias;
        }

        public bool PossuiProduto(int categoriaId)
        {
            return _categoriaService.PossuiProduto(categoriaId);
        }

        public void Remove(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _categoriaService.GetById(categoriaViewModel.CategoriaId);
            _categoriaService.Remove(categoria);
        }

        public void Update(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.Update(Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel));
        }
    }
}
