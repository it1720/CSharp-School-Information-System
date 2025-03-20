using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL.Seeds;
public static class EvalutionSeeds
{
    public static readonly EvaluationEntity Eval = new()
    {
        Id = Guid.Parse("abc8a2cf-ea03-4095-a3e4-aa0291fe9abc"),
        Points = 12.5,
        Comment = "Great Job!",
        StudentId = StudentSeeds.Person1.Id,
        Student = StudentSeeds.Person1,
        ActivityId = ActivitySeeds.Aktivita.Id,
        Activity = ActivitySeeds.Aktivita,
    };

    public static readonly EvaluationEntity Eval2 = new()
    {
        Id = Guid.Parse("abc8a2ef-ea03-4095-a3e4-aa0291fe9abc"),
        Points = 21,
        Comment = "Great Job!",
        StudentId = StudentSeeds.Person1.Id,
        Student = StudentSeeds.Person1,
        ActivityId = ActivitySeeds.Aktivita2.Id,
        Activity = ActivitySeeds.Aktivita2,
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
    modelBuilder.Entity<EvaluationEntity>().HasData(
        Eval with { Student = null!, Activity = null! },
        Eval2 with { Student = null!, Activity = null! }
    );
}
