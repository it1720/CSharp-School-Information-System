using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using ICS_SIS.DAL.Enums;

namespace ICS_SIS.DAL.Seeds;

public static class ActivitySeeds
{
    public static readonly ActivityEntity Aktivita = new()
    {
        Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9d75"),
        Description = "Aktivitka formalitka",
        SubjectId = SubjectSeeds.Izlo.Id,
        Subject = SubjectSeeds.Izlo,
        Start = DateTime.Now,
        End = DateTime.Now,
        Type = ActivityType.Lecture,
    };

    public static readonly ActivityEntity Aktivita2 = new()
    {
        Id = Guid.Parse("06a8a2ef-ea03-4095-a3e4-aa0291fe9d75"),
        Description = "Aktivitka formalitka",
        SubjectId = SubjectSeeds.Izlo.Id,
        Subject = SubjectSeeds.Izlo,
        Start = DateTime.Now,
        End = DateTime.Now,
        Type = ActivityType.Lecture,
    };

    static ActivitySeeds()
    {
        Aktivita.Evaluations.Add(EvalutionSeeds.Eval);

        Aktivita2.Evaluations.Add(EvalutionSeeds.Eval);
    }

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<ActivityEntity>().HasData(
            Aktivita with { Subject = null!, Evaluations = null! },
            Aktivita2 with { Subject = null!, Evaluations = null! }
        );
}