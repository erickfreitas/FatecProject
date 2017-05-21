using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IPerguntaAppService : IAppServiceBase<Pergunta>
    {
        PerguntaViewModel Add(PerguntaViewModel perguntaViewModel);

        IEnumerable<PerguntaViewModel> GetAll();

        PerguntaViewModel GetById(int perguntaId);

        void Remove(PerguntaViewModel perguntaViewModel);

        void Update(PerguntaViewModel perguntaViewModel);

        IEnumerable<PerguntaViewModel> GetByUsuario(string usuarioId);
    }
}
