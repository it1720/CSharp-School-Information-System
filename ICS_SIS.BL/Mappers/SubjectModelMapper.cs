using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Mappers;

public class SubjectModelMapper(StudentSubjectModelMapper studentSubjectModelMapper, ActivityModelMapper activityModelMapper) : ModelMapperBase<SubjectEntity, SubjectListModel, SubjectDetailModel>
{
    public override SubjectDetailModel MapToDetailModel(SubjectEntity? entity)
        => entity is null
            ? SubjectDetailModel.Empty
            : new SubjectDetailModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Acronym = entity.Acronym,
                Activities = activityModelMapper.MapToListModel(entity.Activities).ToObservableCollection(),
                Students = studentSubjectModelMapper.MapToListModel(entity.Students).ToObservableCollection()
            };

    public override SubjectEntity MapToEntity(SubjectDetailModel model)
        => new()
        {
            Id = model.Id,
            Name = model.Name,
            Acronym = model.Acronym,
        };

    public override SubjectListModel MapToListModel(SubjectEntity? entity)
        => entity is null
            ? SubjectListModel.Empty
            : new SubjectListModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Acronym = entity.Acronym,
            };
}