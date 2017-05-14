using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class SubCategoriaRepository : RepositoryBase<SubCategoria>, ISubCategoriaRepository
    {
        public IEnumerable<SubCategoria> GetByCategoria(int categoriaId)
        {
            return Db.SubCategorias.Where(s => s.CategoriaId == categoriaId).OrderBy(s => s.Nome).ToList();
        }

        public override IEnumerable<SubCategoria> GetAll()
        {
            return base.GetAll().OrderBy(c => c.Nome);
        }
    }
}
