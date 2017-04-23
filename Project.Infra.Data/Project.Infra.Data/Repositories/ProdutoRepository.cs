using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;
using System;

namespace Project.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public override IEnumerable<Produto> GetAll()
        {
            return base.GetAll().OrderBy(p => p.Nome);
        }

        public new Produto Add(Produto produto)
        {
            Db.Produtos.Add(produto);
            Db.SaveChanges();
            Db.Entry(produto).GetDatabaseValues();
            return produto;
        }
    }
}
