using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services
{
    public interface IInstituicaoCarenteService : IServiceBase<InstituicaoCarente>
    {
        InstituicaoCarente GetById(string id);
    }
}
