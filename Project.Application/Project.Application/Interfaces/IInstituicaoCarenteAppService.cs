using Project.Application.ViewModels;
using Project.Domain.Entities;
using System.Collections.Generic;

namespace Project.Application.Interfaces
{
    public interface IInstituicaoCarenteAppService : IAppServiceBase<InstituicaoCarente>
    {
        IEnumerable<InstituicaoCarenteViewModel> GetAll();
    }
}
