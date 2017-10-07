using Project.Application.ViewModels;
using Project.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Application.Interfaces
{
    public interface ITrocaAppService : IAppServiceBase<Troca>
    {
        TrocaViewModel Add(TrocaViewModel perguntaViewModel);
        void Update(TrocaViewModel trocaViewModel);
        TrocaViewModel GetById(int trocaId);


        IQueryable<Troca> GetByFilter(Expression<Func<Troca, bool>> filter);

        void Remove(Troca produtoViewModel);
    }
}
