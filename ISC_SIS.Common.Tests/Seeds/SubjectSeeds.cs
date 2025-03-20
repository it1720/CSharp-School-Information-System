using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Seeds;

public static class SubjectSeeds
{
    public static readonly SubjectEntity IzloTest = new()
    {
        Id = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a37"),
        Name = "Zaklady logiky pro informatiky",
        Acronym = "IZLO"
    };

    public static readonly SubjectEntity Subject1 = new()
    {
        Id = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a38"),
        Name = "Informacni systemy",
        Acronym = "IIS"
    };

    public static readonly SubjectEntity Subject2 = new()
    {
        Id = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a39"),
        Name = "Sitove aplikace a sprava siti",
        Acronym = "ISA"
    };
    
    public static readonly SubjectEntity Subject1Update = Subject1 with { Id = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a40") };
    public static readonly SubjectEntity Subject1Delete = Subject1 with { Id = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a41") };

    static SubjectSeeds()
    {
        IzloTest.Students.Add(StudentSubjectSeeds.IzloStudent1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<SubjectEntity>().HasData(
            IzloTest with { Students = null!, Activities = null! },
            Subject1 with { Students = null!, Activities = null! },
            Subject2 with { Students = null!, Activities = null! },
            Subject1Update with { Students = null!, Activities = null! },
            Subject1Delete with { Students = null!, Activities = null! }
        );
}