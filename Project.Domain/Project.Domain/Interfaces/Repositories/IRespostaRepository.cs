using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IRespostaRepository : IRepositoryBase<Resposta>
    {
        new Resposta Add(Resposta produto);

    }
}
