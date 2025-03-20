using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Mappers;

public class EvaluationModelMapper : ModelMapperBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel>
{
    public override EvaluationDetailModel MapToDetailModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationDetailModel.Empty
            : new EvaluationDetailModel
            {
                Id = entity.Id,
                Points = entity.Points,
                Comment = entity.Comment,
                StudentId = entity.StudentId,
                ActivityId = entity.ActivityId,

            };

    public override EvaluationListModel MapToListModel(EvaluationEntity? entity)
        => entity is null
            ? EvaluationListModel.Empty
            : new EvaluationListModel
            {
                Id = entity.Id,
                Points = entity.Points,
                ActivityId = entity.ActivityId,
                StudentId = entity.StudentId,

            };

    public EvaluationListModel MapToListModel(EvaluationDetailModel detailModel)
        => new()
        {
            Id = detailModel.Id,
            Points = detailModel.Points,
            ActivityId = detailModel.ActivityId,
            StudentId = detailModel.StudentId,

        };

    public void MapToExistingDetailModel(EvaluationDetailModel existingDetailModel, StudentListModel student)
    {
        existingDetailModel.StudentId = student.Id;
    }
    public override EvaluationEntity MapToEntity(EvaluationDetailModel model)
        => throw new NotImplementedException("This method is unsupported. Use the other overload.");

    public EvaluationEntity MapToEntity(EvaluationDetailModel model, Guid activityId)
        => new()
        {
            Id = model.Id,
            Points = model.Points,
            Comment = model.Comment,
            StudentId = model.StudentId,
            Student = null!,
            ActivityId = activityId,
            Activity = null!
        };

    public EvaluationEntity MapToEntity(EvaluationListModel model, Guid activityId)
        => new()
        {
            Id = model.Id,
            Points = model.Points,
            StudentId = model.StudentId,
            Student = null!,
            ActivityId = activityId,
            Activity = null!
        };
}