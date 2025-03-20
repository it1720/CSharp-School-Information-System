using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Mappers;

public class StudentModelMapper(StudentSubjectModelMapper studentSubjectModelMapper, EvaluationModelMapper evaluationModelMapper) : ModelMapperBase<StudentEntity, StudentListModel, StudentDetailModel>
{
    public override StudentDetailModel MapToDetailModel(StudentEntity? entity)
        => entity is null
            ? StudentDetailModel.Empty
            : new StudentDetailModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhotoUrl = entity.PhotoUrl,
                Subjects = studentSubjectModelMapper.MapToListModel(entity.Subjects).ToObservableCollection(),
                Evaluations = evaluationModelMapper.MapToListModel(entity.Evaluations).ToObservableCollection()
            };

    public override StudentEntity MapToEntity(StudentDetailModel model)
        => new()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhotoUrl = model.PhotoUrl
        };

    public override StudentListModel MapToListModel(StudentEntity? entity)
        => entity is null
            ? StudentListModel.Empty
            : new StudentListModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
            };
}