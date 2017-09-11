using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Repositories
{
    public interface ITrocaRepository : IRepositoryBase<Troca>
    {
        new Troca Add(Troca troca);
    }
}
