using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Mappers;

public class SubjectEntityMapper : IEntityMapper<SubjectEntity>
{
    public void MapToExistingEntity(SubjectEntity existingEntity, SubjectEntity newEntity)
    {
        existingEntity.Acronym = newEntity.Acronym;
        existingEntity.Name = newEntity.Name;
    }
}