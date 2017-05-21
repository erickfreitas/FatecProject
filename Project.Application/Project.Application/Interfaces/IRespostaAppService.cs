using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IRespostaAppService : IAppServiceBase<Resposta>
    {
        RespostaViewModel Add(RespostaViewModel respostaViewModel);

        IEnumerable<RespostaViewModel> GetAll();

        RespostaViewModel GetById(int respostaId);

        void Remove(RespostaViewModel respostaViewModel);

        void Update(RespostaViewModel respostaViewModel);

        IEnumerable<RespostaViewModel> GetByUsuario(string usuarioId);
    }
}
