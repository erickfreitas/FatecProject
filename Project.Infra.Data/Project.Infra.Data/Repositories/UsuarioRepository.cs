using System;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario GetById(string usuarioId)
        {
            return Db.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        }
    }
}
