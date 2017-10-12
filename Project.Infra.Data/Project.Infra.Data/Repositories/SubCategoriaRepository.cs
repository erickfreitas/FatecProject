using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public bool PossuiProduto(int subCategoriaId)
        {
            return Db.Produtos.Any(p => p.SubCategoriaId == subCategoriaId);
        }
    }
}
