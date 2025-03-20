using ICS_SIS.BL.Mappers;
using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.Repositories;
using ICS_SIS.DAL.UnitOfWork;

namespace ICS_SIS.BL.Facades;

public class EvaluationFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    EvaluationModelMapper EvaluationModelMapper)
    :
        FacadeBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel,
            EvaluationEntityMapper>(unitOfWorkFactory, EvaluationModelMapper), IEvaluationFacade
{

    public async Task SaveAsync(EvaluationDetailModel model, Guid ActivityId)
    {
        EvaluationEntity entity = EvaluationModelMapper.MapToEntity(model, ActivityId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<EvaluationEntity> repository =
            uow.GetRepository<EvaluationEntity, EvaluationEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
        else
        {
            repository.Insert(entity);
            await uow.CommitAsync();
        }
    }

    public async Task SaveAsync(EvaluationListModel model, Guid ActivityId)
    {
        EvaluationEntity entity = EvaluationModelMapper.MapToEntity(model, ActivityId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<EvaluationEntity> repository =
            uow.GetRepository<EvaluationEntity, EvaluationEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
}
