using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
    public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
    {
        public new Resposta Add(Resposta resposta)
        {
            Db.Respostas.Add(resposta);
            Db.SaveChanges();
            Db.Entry(resposta).GetDatabaseValues();
            return resposta;
        }
    }
}
