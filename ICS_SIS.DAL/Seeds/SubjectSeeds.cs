using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity Izlo = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        Name = "Zaklady logiky pro informatiky",
        Acronym = "IZLO",
        Students = new List<StudentSubjectEntity>(), // Initialize the collection
        Activities = new List<ActivityEntity>()
    };

    //static SubjectSeeds()
    //{
    //    Izlo.Students.Add(StudentSubjectSeeds.IzloPerson1);

    //    Izlo.Students.Add(StudentSubjectSeeds.IzloPerson2);

    //    Izlo.Activities.Add(ActivitySeeds.Aktivita);
    //}

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            Izlo with { Students = Array.Empty<StudentSubjectEntity>()!, Activities = Array.Empty<ActivityEntity>() }
        );
}