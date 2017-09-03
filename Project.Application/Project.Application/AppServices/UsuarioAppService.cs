using System;
using System.Collections.Generic;
using Project.Application.Interfaces;
using Project.Application.ViewModels;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;
using AutoMapper;
using System.Linq;
using System.Linq.Expressions;

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

        public void AdicionarImagem(UsuarioImagemViewModel usuarioViewModel)
        {
            var usuario = _usuarioService.GetById(usuarioViewModel.UsuarioId);
            usuario.ImagemCaminho = usuarioViewModel.ImagemCaminho;
            _usuarioService.AdicionarImagem(usuario);
        }

        public IEnumerable<UsuarioViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioService.GetAll());
        }

        public UsuarioViewModel GetById(string usuarioId)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioService.GetById(usuarioId));
        }

        public UsuarioPerfilViewModel GetPerfilById(string usuarioId)
        {
            var perfil = new UsuarioPerfilViewModel();
            var usuario = _usuarioService.GetById(usuarioId);
            perfil.UsuarioViewModel = Mapper.Map<Usuario, UsuarioViewModel>(usuario);
            perfil.UsuarioInformacaoViewModel = Mapper.Map<Usuario, UsuarioInformacaoViewModel>(usuario);
            return perfil;
        }

        public void Remove(int usuarioId)
        {
            throw new NotImplementedException();
        }

        public void RemoverImagem(string usuarioId)
        {
            _usuarioService.RemoverImagem(usuarioId);
        }

        public void Update(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdadeInformacao(UsuarioInformacaoViewModel usuarioViewModel)
        {
            var usuario = _usuarioService.GetById(usuarioViewModel.UsuarioId);
            if (usuario.Endereco == null)
                usuario.Endereco = new Endereco();
            Mapper.Map(usuarioViewModel, usuario);
            Mapper.Map(usuarioViewModel, usuario.Endereco);
            _usuarioService.Update(usuario);
        }

        public IQueryable<Usuario> GetByFilter(Expression<Func<Usuario, bool>> filter)
        {
            return _usuarioService.GetByFilter(filter);
        }
    }
}
