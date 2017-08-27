using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class TrocaRepository : RepositoryBase<Troca>, ITrocaRepository
    {
        public new Troca Add(Troca troca)
        {
            Db.Trocas.Add(troca);
            Db.SaveChanges();
            Db.Entry(troca).GetDatabaseValues();
            return Db.Trocas.Include("Troca").FirstOrDefault(t => t.IdTroca == troca.IdTroca);
        }
    }
}
