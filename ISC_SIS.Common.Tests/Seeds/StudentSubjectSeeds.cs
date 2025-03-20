using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Seeds;

public static class StudentSubjectSeeds
{
    public static readonly StudentSubjectEntity IzloStudent1 = new()
    {
        Id = Guid.Parse("87833e66-05ba-4d6b-900b-fe5ace88dbd8"),
        StudentId = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        SubjectId = Guid.Parse("0d5985b8-14ea-4a5b-b3e9-065d8a0d9a37"),
        Student = null,
        Subject = null
    };
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentSubjectEntity>().HasData(
            IzloStudent1
        );
    }
}