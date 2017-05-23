using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Services
{
    public interface IRespostaService : IServiceBase<Resposta>
    {
        new Resposta Add(Resposta pergunta);
        IEnumerable<Resposta> GetByUsuario(string usuarioId);
    }
}
