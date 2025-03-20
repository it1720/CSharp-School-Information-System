using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Facades;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel, ActivityDetailModel>
{
    Task<IEnumerable<ActivityListModel>> GetAsync(Guid SubjectId, DateTime fromDate, DateTime toDate);
    Task SaveAsync(ActivityDetailModel model, Guid SubjectId);
    Task SaveAsync(ActivityListModel model, Guid SubjectId);
}
