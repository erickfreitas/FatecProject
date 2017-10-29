using System;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class InstituicaoCarenteRepository : RepositoryBase<InstituicaoCarente>, IInstituicaoCarenteRepository
    {
        public InstituicaoCarente GetById(string id)
        {
            return Db.InstituicoesCarentes.FirstOrDefault(i => i.InstituicaoCarenteId == id);
        }
    }
}
