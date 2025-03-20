using ICS_SIS.BL.Mappers;
using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.Repositories;
using ICS_SIS.DAL.UnitOfWork;

namespace ICS_SIS.BL.Facades;

public class StudentSubjectFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    StudentSubjectModelMapper StudentSubjectModelMapper)
    :
        FacadeBase<StudentSubjectEntity, StudentSubjectListModel, StudentSubjectDetailModel,
            StudentSubjectEntityMapper>(unitOfWorkFactory, StudentSubjectModelMapper), IStudentSubjectFacade
{
    public async Task SaveAsync(StudentSubjectListModel model, Guid SubjectId)
    {
        StudentSubjectEntity entity = StudentSubjectModelMapper.MapToEntity(model, SubjectId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }

    public async Task SaveAsync(StudentSubjectDetailModel model, Guid SubjectId)
    {
        StudentSubjectEntity entity = StudentSubjectModelMapper.MapToEntity(model, SubjectId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<StudentSubjectEntity> repository =
            uow.GetRepository<StudentSubjectEntity, StudentSubjectEntityMapper>();

        repository.Insert(entity);
        await uow.CommitAsync();
    }
}
