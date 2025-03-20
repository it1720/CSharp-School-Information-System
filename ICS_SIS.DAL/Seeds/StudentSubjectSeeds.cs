using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL.Seeds;

public static class StudentSubjectSeeds
{
    public static readonly StudentSubjectEntity IzloPerson1 = new()
    {
        Id = Guid.Parse("0d4fa150-ad80-4d46-a511-4c666166ec5e"),
        StudentId = StudentSeeds.Person1.Id,
        SubjectId = SubjectSeeds.Izlo.Id,
        Student = StudentSeeds.Person1,
        Subject = SubjectSeeds.Izlo
    };
    
    public static readonly StudentSubjectEntity IzloPerson2 = new()
    {
        Id = Guid.Parse("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        StudentId = StudentSeeds.Person2.Id,
        SubjectId = SubjectSeeds.Izlo.Id,
        Student = StudentSeeds.Person2,
        Subject = SubjectSeeds.Izlo
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<StudentSubjectEntity>().HasData(
            IzloPerson1 with { Student = null!, Subject = null! },
            IzloPerson2 with { Student = null!, Subject = null! }
        );
}