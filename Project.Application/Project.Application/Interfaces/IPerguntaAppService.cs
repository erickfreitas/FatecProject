using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IPerguntaAppService : IAppServiceBase<Pergunta>
    {
        PerguntaUsuarioViewModel Add(PerguntaViewModel perguntaViewModel);

        IEnumerable<PerguntaViewModel> GetAll();

        PerguntaViewModel GetById(int perguntaId);

        void Remove(PerguntaViewModel perguntaViewModel);

        void Update(PerguntaViewModel perguntaViewModel);

        IEnumerable<PerguntaViewModel> GetByUsuario(string usuarioId);

        IEnumerable<PerguntaUsuarioViewModel> GetByProduto(int produtoId);

        PerguntaUsuarioViewModel GetPerguntaUsuarioById(int perguntaId);
    }
}
