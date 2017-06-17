using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario GetById(string usuarioId);

        void AdicionarImagem(Usuario usuario);
        void RemoverImagem(string usuarioId);
    }
}
