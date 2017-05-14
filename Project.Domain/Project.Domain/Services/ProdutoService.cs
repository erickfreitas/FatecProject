using System;
using System.Collections.Generic;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Domain.Interfaces.Services;

namespace Project.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            :base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public new Produto Add(Produto produto)
        {
            return _produtoRepository.Add(produto);
        }

        public IEnumerable<Produto> GetByUsuario(string usuarioId)
        {
            return _produtoRepository.GetByUsuario(usuarioId);
        }
    }
}
