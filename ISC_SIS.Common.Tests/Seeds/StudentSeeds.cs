using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISC_SIS.Common.Tests.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity EmptyStudentEntity = new()
    {
        Id = default,
        FirstName = default!,
        LastName = default!,
        PhotoUrl = default
    };
    
    public static readonly StudentEntity Student1 = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2e"),
        FirstName = "Lukas",
        LastName = "Holik",
        PhotoUrl = "https://www.fit.vut.cz/person-photo/103996/?transparent=1"
    };
    public static readonly StudentEntity Student2 = new()
    {
        Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf2f"),
        FirstName = "Jakub",
        LastName = "Novak",
        PhotoUrl = default
    };

    public static readonly StudentEntity StudenUpdate = Student1 with { Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf3e") };
    public static readonly StudentEntity StudentDelete = Student1 with { Id = Guid.Parse("fabde0cd-eefe-443f-baf6-3d96cc2cbf4e") };

    static StudentSeeds()
    {
        Student1.Subjects.Add(StudentSubjectSeeds.IzloStudent1);
    }
    
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            Student1 with { Subjects = null!, Evaluations = null! },
            Student2 with { Subjects = null!, Evaluations = null! },
            StudenUpdate with { Subjects = null!, Evaluations = null! },
            StudentDelete with { Subjects = null!, Evaluations = null! }
        );
    }
}