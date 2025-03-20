using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Facades;

public interface IEvaluationFacade : IFacade<EvaluationEntity, EvaluationListModel, EvaluationDetailModel>
{
    Task SaveAsync(EvaluationDetailModel model, Guid ActivityId);
    Task SaveAsync(EvaluationListModel model, Guid ActivityId);
}
