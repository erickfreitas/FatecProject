using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Repositories
{
    public interface IInstituicaoCarenteRepository : IRepositoryBase<InstituicaoCarente>
    {
        InstituicaoCarente GetById(string id);
    }
}
