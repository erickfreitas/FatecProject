﻿using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        new Produto Add(Produto produto);
    }
}
