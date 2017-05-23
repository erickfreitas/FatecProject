using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class PerguntaRepository : RepositoryBase<Pergunta>, IPerguntaRepository
    {
        public new Pergunta Add(Pergunta pergunta)
        {
            Db.Perguntas.Add(pergunta);
            Db.SaveChanges();
            Db.Entry(pergunta).GetDatabaseValues();
            return pergunta;
        }

        public IEnumerable<Pergunta> GetByUsuario(string usuarioId)
        {
            return Db.Perguntas.Where(p => p.UsuarioId == usuarioId).ToList();
        }
    }
}
