using ICS_SIS.BL.Mappers;
using ISC_SIS.Common.Tests;
using ISC_SIS.Common.Tests.Factories;
using ICS_SIS.DAL;
using ICS_SIS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace ICS_SIS.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        // DbContextFactory = new DbContextTestingInMemoryFactory(GetType().Name, seedTestingData: true);
        // DbContextFactory = new DbContextLocalDBTestingFactory(GetType().FullName!, seedTestingData: true);
        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);

        EvaluationModelMapper = new EvaluationModelMapper();
        ActivityModelMapper = new ActivityModelMapper(EvaluationModelMapper);
        StudentSubjectModelMapper = new StudentSubjectModelMapper();
        SubjectModelMapper = new SubjectModelMapper(StudentSubjectModelMapper,ActivityModelMapper);
        StudentModelMapper = new StudentModelMapper(StudentSubjectModelMapper,EvaluationModelMapper);



        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
    }

    protected IDbContextFactory<SISDbContext> DbContextFactory { get; }

    protected EvaluationModelMapper EvaluationModelMapper { get; }
    protected ActivityModelMapper ActivityModelMapper { get; }
    protected SubjectModelMapper SubjectModelMapper { get; }
    protected StudentModelMapper StudentModelMapper { get; }
    protected StudentSubjectModelMapper StudentSubjectModelMapper { get; }
    protected UnitOfWorkFactory UnitOfWorkFactory { get; }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}
