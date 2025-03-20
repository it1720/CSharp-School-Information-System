using ICS_SIS.DAL;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Factories;

public class DbContextSqLiteTestingFactory(string databaseName, bool seedTestingData = false)
    : IDbContextFactory<SISDbContext>
{
    public SISDbContext CreateDbContext()
    {
        DbContextOptionsBuilder<SISDbContext> builder = new();
        builder.UseSqlite($"Data Source={databaseName};Cache=Shared");

        builder.LogTo(Console.WriteLine); //Enable in case you want to see tests details, enabled may cause some inconsistencies in tests
        builder.EnableSensitiveDataLogging();

        return new SISTestingDbContext(builder.Options, seedTestingData);
    }
}
