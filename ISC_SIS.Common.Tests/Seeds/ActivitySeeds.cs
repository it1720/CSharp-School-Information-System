using ICS_SIS.DAL.Entities;
using ICS_SIS.DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity LabTest = new()
    {
        Id = Guid.Parse("a6e45697-1c59-46c3-89e7-6328b1e1e39f"),
        Start = new DateTime(2024, 3, 6, 12, 0, 0),
        End = new DateTime(2024, 3, 6, 14, 0, 0),
        Subject = null,
        SubjectId = SubjectSeeds.IzloTest.Id,
        Description = "This is a test of ActivityEntity seed",
        Place = Room.Lab,
        Type = ActivityType.Lab
    };

    public static readonly ActivityEntity LabTest2 = new()
    {
        Id = Guid.Parse("a6e45697-1c59-46c3-89e7-6328b1e1e39e"),
        Start = new DateTime(2023, 3, 6, 12, 0, 0),
        End = new DateTime(2023, 3, 6, 14, 0, 0),
        Subject = null,
        SubjectId = SubjectSeeds.IzloTest.Id,
        Description = "This is a test of ActivityEntity seed",
        Place = Room.Lab,
        Type = ActivityType.Lab
    };

    public static readonly ActivityEntity LabTest3 = new()
    {
        Id = Guid.Parse("a6e45697-1c59-46c3-89e7-6328b1e1e39d"),
        Start = new DateTime(2022, 3, 6, 12, 0, 0),
        End = new DateTime(2022, 3, 6, 14, 0, 0),
        Subject = null,
        SubjectId = SubjectSeeds.IzloTest.Id,
        Description = "This is a test of ActivityEntity seed",
        Place = Room.Lab,
        Type = ActivityType.Lab
    };

    public static readonly ActivityEntity LabTest2Update = LabTest2 with { Id = Guid.Parse("a6e45697-1c59-46c3-89e7-6328b1e1e39c") };
    public static readonly ActivityEntity LabTest2Delete = LabTest2 with { Id = Guid.Parse("a6e45697-1c59-46c3-89e7-6328b1e1e39b") };
    
    static ActivitySeeds()
    {
        LabTest.Evaluations.Add(EvaluationSeeds.EvaluationSeedTest);
    }
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityEntity>().HasData(
            LabTest with { Evaluations = null! },
            LabTest2 with { Evaluations = null! },
            LabTest3 with { Evaluations = null! },
            LabTest2Update with { Evaluations = null! },
            LabTest2Delete with { Evaluations = null! }
        );
    }
}