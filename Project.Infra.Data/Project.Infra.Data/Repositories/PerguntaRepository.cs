using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project.Infra.Data.Repositories
{
    public class PerguntaRepository : RepositoryBase<Pergunta>, IPerguntaRepository
    {
        public new Pergunta Add(Pergunta pergunta)
        {
            Db.Perguntas.Add(pergunta);
            Db.SaveChanges();
            Db.Entry(pergunta).GetDatabaseValues();
            return Db.Perguntas.Include("Usuario").FirstOrDefault(p => p.PerguntaId == pergunta.PerguntaId);
        }

        public IEnumerable<Pergunta> GetByProduto(int produtoId)
        {
            return Db.Perguntas.AsNoTracking().Include("Usuario").Where(p => p.ProdutoId == produtoId).OrderByDescending(p => p.PerguntaId);
        }

        public IEnumerable<Pergunta> GetByUsuario(string usuarioId)
        {
            return Db.Perguntas.Where(p => p.UsuarioId == usuarioId).ToList();
        }

        public override Pergunta GetById(int id)
        {
            return Db.Perguntas.Include("Usuario").FirstOrDefault(p => p.PerguntaId == id);
        }
    }
}
