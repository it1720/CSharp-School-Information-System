using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;

namespace ICS_SIS.BL.Facades;

public interface IStudentSubjectFacade {
    Task SaveAsync(StudentSubjectDetailModel model, Guid SubjectId);
    Task SaveAsync(StudentSubjectListModel model, Guid SubjectId);
    Task DeleteAsync(Guid id);
}
