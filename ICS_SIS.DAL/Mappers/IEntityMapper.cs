using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Mappers;
public interface IEntityMapper<in TEntity>
        where TEntity : IEntity
    {
        void MapToExistingEntity(TEntity existingEntity, TEntity newEntity);
    }

