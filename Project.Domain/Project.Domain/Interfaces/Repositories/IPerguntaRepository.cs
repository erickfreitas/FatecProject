using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IPerguntaRepository : IRepositoryBase<Pergunta>
    {
        new Pergunta Add(Pergunta pergunta);

        IEnumerable<Pergunta> GetByUsuario(string usuarioId);

    }
}
