using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.Repositories;

namespace ICS_SIS.DAL.UnitOfWork;

public interface IUnitOfWork : IAsyncDisposable
{
    IRepository<TEntity> GetRepository<TEntity, TEntityMapper>()
        where TEntity : class, IEntity
        where TEntityMapper : IEntityMapper<TEntity>, new();

    Task CommitAsync();
}