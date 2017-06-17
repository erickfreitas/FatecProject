using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        UsuarioViewModel Add(UsuarioViewModel usuarioViewModel);

        IEnumerable<UsuarioViewModel> GetAll();

        UsuarioViewModel GetById(string usuarioId);

        void Remove(int usuarioId);

        void Update(UsuarioViewModel usuarioViewModel);

        void RemoverImagem(string usuarioId);

        void AdicionarImagem(UsuarioImagemViewModel usuarioViewModel);

        UsuarioPerfilViewModel GetPerfilById(string usuarioId);

        void UpdadeInformacao(UsuarioInformacaoViewModel usuarioViewModel);
    }
}
