using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;

namespace Project.Application.AppServices
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
            :base(usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioViewModel Add(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.GetAll());
        }

        public UsuarioViewModel GetById(string usuarioId)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.GetById(usuarioId));
        }

        public void Remove(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
