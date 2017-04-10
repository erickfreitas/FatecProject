using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

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

        public void Remove(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.Remove(Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel));
        }

        public void Update(CategoriaViewModel categoriaViewModel)
        {
            _categoriaService.Update(Mapper.Map<CategoriaViewModel, Categoria>(categoriaViewModel));
        }
    }
}
