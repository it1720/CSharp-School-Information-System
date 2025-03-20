using ICS_SIS.DAL.Entities;

namespace ICS_SIS.DAL.Mappers;

public class StudentSubjectEntityMapper : IEntityMapper<StudentSubjectEntity>
{
    public void MapToExistingEntity(StudentSubjectEntity existingEntity, StudentSubjectEntity newEntity)
    {
        existingEntity.StudentId = newEntity.StudentId;
        existingEntity.SubjectId = newEntity.SubjectId;
    }
}