using Project.Application.Interfaces;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Services;

namespace Project.Application.AppServices
{
    public class TrocaAppService : AppServiceBase<Troca>, ITrocaAppService
    {
        private readonly ITrocaService _trocaService;

        public TrocaAppService(ITrocaService trocaService)
            :base(trocaService)
        {
            _trocaService = trocaService;
        }
    }
}
