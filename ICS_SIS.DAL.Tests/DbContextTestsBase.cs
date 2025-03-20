using ISC_SIS.Common.Tests;
using ISC_SIS.Common.Tests.Factories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace ICS_SIS.DAL.Tests;

public class DbContextTestsBase : IAsyncLifetime
{
    protected DbContextTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);
        SISDbContextSUT = DbContextFactory.CreateDbContext();
    }

    protected IDbContextFactory<SISDbContext> DbContextFactory { get; }
    protected SISDbContext SISDbContextSUT { get; }


    public async Task InitializeAsync()
    {
        await SISDbContextSUT.Database.EnsureDeletedAsync();
        await SISDbContextSUT.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await SISDbContextSUT.Database.EnsureDeletedAsync();
        await SISDbContextSUT.DisposeAsync();
    }
}
