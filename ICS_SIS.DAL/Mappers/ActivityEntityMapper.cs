using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Mappers;

public class ActivityEntityMapper : IEntityMapper<ActivityEntity>
{
    public void MapToExistingEntity(ActivityEntity existingEntity, ActivityEntity newEntity)
    {
        existingEntity.Description = newEntity.Description;
        existingEntity.End = newEntity.End;
        existingEntity.Place = newEntity.Place;
        existingEntity.Start = newEntity.Start;
        existingEntity.Type = newEntity.Type;
        existingEntity.SubjectId = newEntity.SubjectId;
    }
}