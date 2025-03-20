using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Mappers;

public class EvaluationEntityMapper : IEntityMapper<EvaluationEntity>
{
    public void MapToExistingEntity(EvaluationEntity existingEntity, EvaluationEntity newEntity)
    {
        existingEntity.Comment = newEntity.Comment;
        existingEntity.Points = newEntity.Points;
        existingEntity.ActivityId = newEntity.ActivityId;
        existingEntity.StudentId = newEntity.StudentId;
    }
}