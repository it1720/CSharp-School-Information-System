using ICS_SIS.DAL.Factories;
using ICS_SIS.DAL.Mappers;
using ICS_SIS.DAL.Migrator;
using ICS_SIS.DAL.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICS_SIS.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, DALOptions options)
    {
        services.AddSingleton(options);

        if (options is null)
        {
            throw new InvalidOperationException("No persistence provider configured");
        }

        if (string.IsNullOrEmpty(options.DatabaseDirectory))
        {
            throw new InvalidOperationException($"{nameof(options.DatabaseDirectory)} is not set");
        }
        if (string.IsNullOrEmpty(options.DatabaseName))
        {
            throw new InvalidOperationException($"{nameof(options.DatabaseName)} is not set");
        }

        services.AddSingleton<IDbContextFactory<SISDbContext>>(_ =>
            new DbContextSqLiteFactory(options.DatabaseFilePath, options?.SeedDemoData ?? false));
        services.AddSingleton<IDbMigrator, DbMigrator>();

        services.AddSingleton<ActivityEntityMapper>();

        services.AddSingleton<StudentEntityMapper>();
        services.AddSingleton<StudentSubjectEntityMapper>();
        services.AddSingleton<EvaluationEntityMapper>();
        services.AddSingleton<SubjectEntityMapper>();

        return services;
    }
}
