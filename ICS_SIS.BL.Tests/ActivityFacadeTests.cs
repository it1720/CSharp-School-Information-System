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

public sealed class ActivityFacadeTests : FacadeTestsBase
{
    private readonly IActivityFacade _ActivityFacadeSUT;

    public ActivityFacadeTests(ITestOutputHelper output) : base(output)
    {
        _ActivityFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new ActivityDetailModel()
        {
            Id = Guid.Empty,
            SubjectId = Guid.Empty,
            Start = new DateTime(2024, 3, 6, 12, 0, 0),
            End = new DateTime(2024, 3, 6, 14, 0, 0),
            Description = "This is a test of ActivityEntity seed",
        };

        await _ActivityFacadeSUT.SaveAsync(model,SubjectSeeds.Subject1.Id);
    }

    [Fact]
    public async Task GetAll_Activities_ContainsSeededLabTest()
    {
        //act
        var Activities = await _ActivityFacadeSUT.GetAsync();
        var Activity = ActivityModelMapper.MapToListModel(ActivitySeeds.LabTest2);


        //Assert
        DeepAssert.Contains(Activity, Activities);
    }

    [Fact]
    public async Task GetById_Activity_ContainsSeededActivity1()
    {
        //act
        var Activity = await _ActivityFacadeSUT.GetAsync(ActivitySeeds.LabTest2.Id);

        //Assert
        DeepAssert.Equal(ActivityModelMapper.MapToDetailModel(ActivitySeeds.LabTest2), Activity);
    }

    [Fact]
    public async Task Update_Activity_ContainsUpdatedActivity1()
    {
        //Arrange
        var model = ActivityModelMapper.MapToDetailModel(ActivitySeeds.LabTest2);
        model.Description = "This is a test of updating an activity";

        //Act
        await _ActivityFacadeSUT.SaveAsync(model with {Evaluations = default! }, SubjectSeeds.Subject1.Id);

        //Assert
        var Activity = await _ActivityFacadeSUT.GetAsync(model.Id);
        DeepAssert.Equal(model, Activity);
    }

    [Fact]
    public async Task Delete_Activity_ContainsDeletedActivity1()
    {
        //Arrange
        var Activity = ActivityModelMapper.MapToListModel(ActivitySeeds.LabTest2Delete);
        await _ActivityFacadeSUT.DeleteAsync(ActivitySeeds.LabTest2Delete.Id);
        var Activities = await _ActivityFacadeSUT.GetAsync();

        DeepAssert.DoesNotContain(Activity, Activities);
    }

    [Fact]
    public async Task FilterActivitiesTest()
    {
        var Activities = await _ActivityFacadeSUT.GetAsync(SubjectSeeds.IzloTest.Id,new DateTime(2023, 1, 1, 0, 0, 0), new DateTime(2023, 12, 31, 23, 59, 59));
        var ActivitiesAll = await _ActivityFacadeSUT.GetAsync();
        DeepAssert.DoesNotContain(ActivityModelMapper.MapToListModel(ActivitySeeds.LabTest), Activities);
    }


}
