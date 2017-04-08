using Project.Application.Interfaces;
using Project.Domain.Interfaces.Services;
using System;

namespace Project.Application.AppServices
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
