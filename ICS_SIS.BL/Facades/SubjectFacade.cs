using ICS_SIS.BL.Mappers;
using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.UnitOfWork;

namespace ICS_SIS.BL.Facades
{
    public class SubjectFacade(
        IUnitOfWorkFactory unitOfWorkFactory,
        SubjectModelMapper modelMapper)
        : FacadeBase<SubjectEntity, SubjectListModel, SubjectDetailModel, SubjectEntityMapper>(unitOfWorkFactory, modelMapper),
            ISubjectFacade
    {
        protected override ICollection<string> IncludesNavigationPathDetail =>
            new[]
            {
                $"{nameof(SubjectEntity.Students)}.{nameof(StudentSubjectEntity.Student)}",
                nameof(SubjectEntity.Activities),
            };
    }
}

