using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface IPerguntaService : IServiceBase<Pergunta>
    {
        new Pergunta Add(Pergunta pergunta);
        IEnumerable<Pergunta> GetByUsuario(string usuarioId);
    }
}
