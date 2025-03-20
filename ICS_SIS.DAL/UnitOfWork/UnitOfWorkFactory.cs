using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL.UnitOfWork;

public class UnitOfWorkFactory(IDbContextFactory<SISDbContext> dbContextFactory) : IUnitOfWorkFactory
{
    public IUnitOfWork Create() => new UnitOfWork(dbContextFactory.CreateDbContext());
}