using System;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
            :base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void AdicionarImagem(Usuario usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public Usuario GetById(string usuarioId)
        {
            return _usuarioRepository.GetById(usuarioId);
        }

        public void RemoverImagem(string usuarioId)
        {
            var usuario = _usuarioRepository.GetById(usuarioId);
            usuario.ImagemCaminho = null;
            _usuarioRepository.Update(usuario);
        }
    }
}
