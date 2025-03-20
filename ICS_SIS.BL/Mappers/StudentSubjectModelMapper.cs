using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Mappers;

public class StudentSubjectModelMapper : ModelMapperBase<StudentSubjectEntity, StudentSubjectListModel, StudentSubjectDetailModel>
{
    public override StudentSubjectDetailModel MapToDetailModel(StudentSubjectEntity? entity)
        => entity?.Student is null
            ? StudentSubjectDetailModel.Empty
            : new StudentSubjectDetailModel
            {
                Id = entity.Id,
                StudentId = entity.Student.Id,
                StudentFirstName = entity.Student.FirstName,
                StudentLastName = entity.Student.FirstName,
                StudentPhotoUrl = entity.Student.PhotoUrl,
                SubjectId = entity.Subject.Id,
                SubjectName = entity.Subject.Name,
                SubjectAcronym = entity.Subject.Acronym,
            };


    public override StudentSubjectListModel MapToListModel(StudentSubjectEntity? entity)
        => entity?.Student is null
            ? StudentSubjectListModel.Empty
            : new StudentSubjectListModel
            {
                Id = entity.Id,
                StudentId = entity.Student.Id,
                StudentFirstName = entity.Student.FirstName,
                StudentLastName = entity.Student.LastName,
                SubjectId = entity.Subject.Id,
                SubjectName = entity.Subject.Name,
                SubjectAcronym = entity.Subject.Acronym,
            };
    public StudentSubjectListModel MapToListModel(StudentSubjectDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            StudentId = detailModel.StudentId,
            StudentFirstName = detailModel.StudentFirstName,
            StudentLastName = detailModel.StudentLastName,
            SubjectId = detailModel.SubjectId,
            SubjectName = detailModel.SubjectName,
            SubjectAcronym = detailModel.SubjectAcronym,
        };

    public void MapToExistingDetailModel(StudentSubjectDetailModel existingDetailModel, StudentListModel student)
    {
        existingDetailModel.StudentId = student.Id;
        existingDetailModel.StudentFirstName = student.FirstName;
        existingDetailModel.StudentLastName = student.LastName;
        existingDetailModel.StudentPhotoUrl = student.PhotoUrl;
    }

    public override StudentSubjectEntity MapToEntity(StudentSubjectDetailModel model)
    {
        throw new NotImplementedException("This method is unsupported. Use the other overload.");
    }

    public StudentSubjectEntity MapToEntity(StudentSubjectDetailModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = model.StudentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };

    public StudentSubjectEntity MapToEntity(StudentSubjectListModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            StudentId = model.StudentId,
            SubjectId = subjectId,
            Student = null!,
            Subject = null!
        };

}