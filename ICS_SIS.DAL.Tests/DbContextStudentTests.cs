using ICS_SIS.DAL.Entities;
using ISC_SIS.Common.Tests;
using Microsoft.EntityFrameworkCore;
using ISC_SIS.Common.Tests.Seeds;
using Xunit.Abstractions;

namespace ICS_SIS.DAL.Tests;

public class DbContextStudentTests(ITestOutputHelper output) : DbContextTestsBase(output)
{
    [Fact]
    public async Task AddNew_Student_Persisted()
    {
        //Arrange
        StudentEntity entity = new()
        {
            Id = Guid.Parse("e3b8335e-7813-4d39-b682-3776198c476f"),
            FirstName = "Kurt",
            LastName = "Godel",
            PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Young_Kurt_G%C3%B6del_as_a_student_in_1925.jpg/225px-Young_Kurt_G%C3%B6del_as_a_student_in_1925.jpg",
            Subjects = Array.Empty<StudentSubjectEntity>(), 
            Evaluations = Array.Empty<EvaluationEntity>()
        };

        //Act
        SISDbContextSUT.Students.Add(entity);
        await SISDbContextSUT.SaveChangesAsync();

        //Assert
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var actualEntities = await dbx.Students.SingleAsync(i => i.Id == entity.Id);
        
        DeepAssert.Equal(entity, actualEntities);
    }

    [Fact]
    public async Task GetAll_Students_ContainsSeededPerson1()
    {
        //act
        var entities = await SISDbContextSUT.Students.ToArrayAsync();
        
        foreach (var entity in entities)
        {
            // Concatenate subjects into a string
            string subjectsString = string.Join(", ", entity.Subjects);

            Console.WriteLine($"Retrieved Student: {entity.Id}, {entity.FirstName}, {entity.LastName}, Subjects: {subjectsString}");
        }
        
        //Assert
        DeepAssert.Contains(StudentSeeds.Student1, entities);
    }
}
