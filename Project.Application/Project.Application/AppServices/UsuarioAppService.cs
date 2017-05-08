using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;

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
    }
}
