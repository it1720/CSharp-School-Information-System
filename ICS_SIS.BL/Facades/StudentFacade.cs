using ICS_SIS.BL.Mappers;
using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.UnitOfWork;

namespace ICS_SIS.BL.Facades
{
    public class StudentFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        StudentModelMapper modelMapper)
        : FacadeBase<StudentEntity, StudentListModel, StudentDetailModel, StudentEntityMapper>(unitOfWorkFactory, modelMapper),
            IStudentFacade
    {
        protected override ICollection<string> IncludesNavigationPathDetail =>
            new[]
            {
                $"{nameof(StudentEntity.Subjects)}.{nameof(StudentSubjectEntity.Subject)}",
                $"{nameof(StudentEntity.Evaluations)}"
            };
    }
}