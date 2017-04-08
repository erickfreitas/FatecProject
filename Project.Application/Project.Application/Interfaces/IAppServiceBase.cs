namespace Project.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Dispose();
    }
}
