using Project.Application.ViewModels;
using Project.Domain.Entities;

namespace Project.Application.Interfaces
{
    public interface ITrocaAppService : IAppServiceBase<Troca>
    {
        TrocaViewModel Add(TrocaViewModel perguntaViewModel);
        void Update(TrocaViewModel trocaViewModel);
    }
}
