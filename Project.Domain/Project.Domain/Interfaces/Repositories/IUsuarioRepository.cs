using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario GetById(string usuarioId);
    }
}
