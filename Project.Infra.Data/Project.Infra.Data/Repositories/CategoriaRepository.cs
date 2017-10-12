using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;
using System;

namespace Project.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        public override IEnumerable<Categoria> GetAll()
        {
            return base.GetAll().OrderBy(c => c.Nome);
        }

        public IEnumerable<Categoria> GetCategoriasAtivas()
        {
            return Db.Categorias.Include("SubCategorias").Where(c => c.MostrarNoMenuInicial);
        }

        public bool PossuiProduto(int categoriaId)
        {
            return Db.Produtos.Any(p => p.CategoriaId == categoriaId);
        }
    }
}
