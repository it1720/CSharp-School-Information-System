using ICS_SIS.DAL;
using ISC_SIS.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests;

public class SISTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false) : SISDbContext(contextOptions, seedDemoData: false)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        if (seedTestingData)
        {
            StudentSeeds.Seed(modelBuilder);
            SubjectSeeds.Seed(modelBuilder);
            StudentSubjectSeeds.Seed(modelBuilder);
            EvaluationSeeds.Seed(modelBuilder);
            ActivitySeeds.Seed(modelBuilder);
        }
    }
}
