using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public override IEnumerable<Categoria> GetAll()
        {
            return base.GetAll().OrderBy(c => c.Nome);
        }
    }
}
