using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class ProdutoImagemService : ServiceBase<ProdutoImagem>, IProdutoImagemService
    {

        private readonly IProdutoImagemRepository _produtoImagemRepository;

        public ProdutoImagemService(IProdutoImagemRepository produtoImagemRepository)
            :base(produtoImagemRepository)
        {
            _produtoImagemRepository = produtoImagemRepository;
        }
    }
}
