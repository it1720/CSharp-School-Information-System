using ICS_SIS.BL.Facades;
using ICS_SIS.BL.Models;
using ISC_SIS.Common.Tests;
using ISC_SIS.Common.Tests.Seeds;
using ICS_SIS.BL.Tests;
using ICS_SIS.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;
using Xunit.Abstractions;

namespace ICS_SIS.BL.Tests;

public sealed class StudentFacadeTests : FacadeTestsBase
{
    private readonly IStudentFacade _StudentFacadeSUT;

    public StudentFacadeTests(ITestOutputHelper output) : base(output)
    {
        _StudentFacadeSUT = new StudentFacade(UnitOfWorkFactory, StudentModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new StudentDetailModel()
        {
            Id = Guid.Empty,
            FirstName = @"Jakub",
            LastName = @"Novak",
        };

        var _ = await _StudentFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Students_ContainsSeededStudent1()
    {
        //act
        var students = await _StudentFacadeSUT.GetAsync();
        var student = students.Single(i => i.Id == StudentSeeds.Student1.Id);


        //Assert
        DeepAssert.Equal(StudentModelMapper.MapToListModel(StudentSeeds.Student1), student);
    }

    [Fact]
    public async Task GetById_Student_ContainsSeededStudent1()
    {
        //act
        var student = await _StudentFacadeSUT.GetAsync(StudentSeeds.Student1.Id);

        //Assert
        DeepAssert.Equal(StudentModelMapper.MapToDetailModel(StudentSeeds.Student1), student);
    }

    [Fact]
    public async Task Update_Student_ContainsUpdatedStudent1()
    {
        //Arrange
        var model = StudentModelMapper.MapToDetailModel(StudentSeeds.Student1);
        model.FirstName = "Rehor";

        //Act
        await _StudentFacadeSUT.SaveAsync(model with { Subjects = default!, Evaluations = default!});

        //Assert
        var student = await _StudentFacadeSUT.GetAsync(model.Id);
        DeepAssert.Equal(model, student);
    }

    [Fact]
    public async Task Delete_Student_ContainsDeletedStudent1()
    {
        //Arrange
        await _StudentFacadeSUT.DeleteAsync(StudentSeeds.StudentDelete.Id);
    }


}
