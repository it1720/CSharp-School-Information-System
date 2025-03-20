using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Repositories;
public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Get();
        Task DeleteAsync(Guid entityId);
        ValueTask<bool> ExistsAsync(TEntity entity);
        TEntity Insert(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }

