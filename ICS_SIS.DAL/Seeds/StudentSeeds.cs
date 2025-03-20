using ICS_SIS.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICS_SIS.DAL.Seeds;

public static class StudentSeeds
{
    public static readonly StudentEntity Person1 = new()
    {
        Id = Guid.Parse("06a8a2cf-ea03-4095-a3e4-aa0291fe9c75"),
        FirstName = "Kurt",
        LastName = "Godel",
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Young_Kurt_G%C3%B6del_as_a_student_in_1925.jpg/225px-Young_Kurt_G%C3%B6del_as_a_student_in_1925.jpg",
        Subjects = new List<StudentSubjectEntity>(),     // Initialize the collection
        Evaluations = new List<EvaluationEntity>()
    };

    public static readonly StudentEntity Person2 = new()
    {
        Id = Guid.Parse("06f8a2cf-ea03-4095-a3e4-ab0291fe9c75"),
        FirstName = "Bertrand",
        LastName = "Russell",
        PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9b/Honourable_Bertrand_Russell.jpg/230px-Honourable_Bertrand_Russell.jpg",
        Subjects = new List<StudentSubjectEntity>(),     // Initialize the collection
        Evaluations = new List<EvaluationEntity>()
    };

    //static StudentSeeds()
    //{
    //    Person1.Subjects.Add(StudentSubjectSeeds.IzloPerson1);

    //    Person2.Subjects.Add(StudentSubjectSeeds.IzloPerson2);

    //    Person1.Evaluations.Add(EvalutionSeeds.Eval);
    //}

    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentEntity>().HasData(
            Person1 with { Subjects = Array.Empty<StudentSubjectEntity>(), Evaluations = Array.Empty<EvaluationEntity>() },
            Person2 with { Subjects = Array.Empty<StudentSubjectEntity>(), Evaluations = Array.Empty<EvaluationEntity>() }
        );
    }
}
