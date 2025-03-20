using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Seeds;

public static class EvaluationSeeds
{
    public static readonly EvaluationEntity EvaluationSeedTest = new()
    {
        Id = Guid.Parse("f3093c27-9bc2-4e41-8904-5767a575d1e2"),
        Points = 15,
        Comment = "Great job!",
        StudentId = StudentSeeds.Student1.Id,
        ActivityId = ActivitySeeds.LabTest.Id,
        Student = null,
        Activity = null
    };

    public static readonly EvaluationEntity EvaluationSeedTestUpdate = EvaluationSeedTest with { Id = Guid.Parse("f3093c27-9bc2-4e41-8904-5767a575d1e3") };
    public static readonly EvaluationEntity EvaluationSeedTestDelete = EvaluationSeedTest with { Id = Guid.Parse("f3093c27-9bc2-4e41-8904-5767a575d1e4") };

    public static readonly EvaluationEntity EvaluationSeedTest2 = new()
    {
        Id = Guid.Parse("f3093c27-9bc2-4e41-8904-5767a575d1e5"),
        Points = 10,
        Comment = "Good job!",
        StudentId = StudentSeeds.Student1.Id,
        ActivityId = ActivitySeeds.LabTest.Id,
        Student = null,
        Activity = null
    };  

    public static readonly EvaluationEntity EvaluationSeedTest3 = new()
    {
        Id = Guid.Parse("f3093c27-9bc2-4e41-8904-5767a575d1e6"),
        Points = 5,
        Comment = "Bad job!",
        StudentId = StudentSeeds.Student1.Id,
        ActivityId = ActivitySeeds.LabTest.Id,
        Student = null,
        Activity = null
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EvaluationEntity>().HasData(
            EvaluationSeedTest,
            EvaluationSeedTest2,
            EvaluationSeedTest3,
            EvaluationSeedTestUpdate,
            EvaluationSeedTestDelete
        );
    }
}