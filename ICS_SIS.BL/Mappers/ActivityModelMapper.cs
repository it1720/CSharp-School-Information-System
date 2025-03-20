using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Enums;

namespace ICS_SIS.BL.Mappers;

public class ActivityModelMapper(EvaluationModelMapper evaluationModelMapper) : ModelMapperBase<ActivityEntity, ActivityListModel, ActivityDetailModel>
{
    public override ActivityDetailModel MapToDetailModel(ActivityEntity? entity)
        => entity is null
            ? ActivityDetailModel.Empty
            : new ActivityDetailModel
            {
                Id = entity.Id,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place,
                Type = entity.Type,
                SubjectId = entity.SubjectId,
                Description = entity.Description,
                Evaluations = evaluationModelMapper.MapToListModel(entity.Evaluations).ToObservableCollection()
            };
    public override ActivityListModel MapToListModel(ActivityEntity? entity)
        => entity is null
            ? ActivityListModel.Empty
            : new ActivityListModel
            {
                Id = entity.Id,
                Start = entity.Start,
                End = entity.End,
                Place = entity.Place,
                Type = entity.Type,
                SubjectId = entity.SubjectId,
            };

    public ActivityListModel MapToListModel(ActivityDetailModel detailModel)
        => new()
            {
                Id = detailModel.Id,
                Start = detailModel.Start,
                End = detailModel.End,
                Place = detailModel.Place,
                Type = detailModel.Type,
                SubjectId = detailModel.SubjectId,
        };

    public override ActivityEntity MapToEntity(ActivityDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public ActivityEntity MapToEntity(ActivityDetailModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            Start = model.Start,
            End = model.End,
            Place = model.Place,
            Type = model.Type,
            Description= model.Description,
            SubjectId = subjectId,
            Subject = null!
        };

    public ActivityEntity MapToEntity(ActivityListModel model, Guid subjectId)
        => new()
        {
            Id = model.Id,
            Start = model.Start,
            End = model.End,
            Place = model.Place,
            Type = model.Type,
            SubjectId = subjectId,
            Subject = null!
        };

}