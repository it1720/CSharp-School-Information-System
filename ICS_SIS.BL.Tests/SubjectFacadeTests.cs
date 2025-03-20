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

public sealed class SubjectFacadeTests : FacadeTestsBase
{
    private readonly ISubjectFacade _SubjectFacadeSUT;

    public SubjectFacadeTests(ITestOutputHelper output) : base(output)
    {
        _SubjectFacadeSUT = new SubjectFacade(UnitOfWorkFactory, SubjectModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new SubjectDetailModel()
        {
            Id = Guid.Empty,
            Name = @"Uvod do softwaroveho inzenyrstvi",
            Acronym = @"IUS",
        };

        var _ = await _SubjectFacadeSUT.SaveAsync(model);
    }

    [Fact]
    public async Task GetAll_Subjects_ContainsSeededSubject1()
    {
        //act
        var Subjects = await _SubjectFacadeSUT.GetAsync();
        var Subject = Subjects.Single(i => i.Id == SubjectSeeds.Subject1.Id);


        //Assert
        DeepAssert.Equal(SubjectModelMapper.MapToListModel(SubjectSeeds.Subject1), Subject);
    }

    [Fact]
    public async Task GetById_Subject_ContainsSeededSubject1()
    {
        //act
        var Subject = await _SubjectFacadeSUT.GetAsync(SubjectSeeds.Subject1.Id);

        //Assert
        DeepAssert.Equal(SubjectModelMapper.MapToDetailModel(SubjectSeeds.Subject1), Subject);
    }

    [Fact]
    public async Task Update_Subject_ContainsUpdatedSubject1()
    {
        //Arrange
        var model = SubjectModelMapper.MapToDetailModel(SubjectSeeds.Subject1Update);
        model.Name = "Algoritmy";

        //Act
        await _SubjectFacadeSUT.SaveAsync(model with { Students = default!, Activities = default! });

        //Assert
        var Subject = await _SubjectFacadeSUT.GetAsync(model.Id);
        DeepAssert.Equal(model, Subject);
    }

    [Fact]
    public async Task Delete_Subject_ContainsDeletedSubject1()
    {
        //Arrange
        await _SubjectFacadeSUT.DeleteAsync(SubjectSeeds.Subject1Delete.Id);
    }


}
