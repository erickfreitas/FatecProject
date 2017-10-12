using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ProjectContext Db = new ProjectContext();
        
        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public virtual void Update(TEntity obj)
        {
            Db.Set<TEntity>().Attach(obj);
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> query = Db.Set<TEntity>().Where(filter);
            return query;
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
