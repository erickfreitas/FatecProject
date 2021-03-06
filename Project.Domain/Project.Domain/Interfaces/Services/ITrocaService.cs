﻿using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services
{
    public interface ITrocaService : IServiceBase<Troca>
    {
        new Troca Add(Troca troca);
    }
}
