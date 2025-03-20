using ICS_SIS.BL.Mappers;
using ICS_SIS.BL.Models;
using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.Repositories;
using ICS_SIS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.BL.Facades;

public class ActivityFacade(
    IUnitOfWorkFactory unitOfWorkFactory,
    ActivityModelMapper modelMapper)
    : FacadeBase<ActivityEntity, ActivityListModel, ActivityDetailModel, ActivityEntityMapper>(unitOfWorkFactory, modelMapper),
        IActivityFacade
{
    protected override ICollection<string> IncludesNavigationPathDetail =>
        new[]
        {
            nameof(ActivityEntity.Evaluations)
        };


    public virtual async Task<IEnumerable<ActivityListModel>> GetAsync(Guid subjectId, DateTime fromDate, DateTime toDate)
    {
        await using IUnitOfWork uow = UnitOfWorkFactory.Create();

        IQueryable<ActivityEntity> query = uow.GetRepository<ActivityEntity, ActivityEntityMapper>()
            .Get()
            .Where(a => a.SubjectId == subjectId && a.Start >= fromDate && a.End <= toDate);
        foreach (string includePath in IncludesNavigationPathDetail)
        {
            query = query.Include(includePath);
        }

        List<ActivityEntity> entities = await query.ToListAsync().ConfigureAwait(false);
        
        return ModelMapper.MapToListModel(entities);
    }
    public async Task SaveAsync(ActivityDetailModel model, Guid subjectId)
    {
        ActivityEntity entity = modelMapper.MapToEntity(model, subjectId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            uow.GetRepository<ActivityEntity, ActivityEntityMapper>();

        repository.Insert(entity);
        await uow.CommitAsync();
    }

    public async Task SaveAsync(ActivityListModel model, Guid subjectId)
    {
        ActivityEntity entity = modelMapper.MapToEntity(model, subjectId);

        await using IUnitOfWork uow = UnitOfWorkFactory.Create();
        IRepository<ActivityEntity> repository =
            uow.GetRepository<ActivityEntity, ActivityEntityMapper>();

        if (await repository.ExistsAsync(entity))
        {
            await repository.UpdateAsync(entity);
            await uow.CommitAsync();
        }
    }
}
