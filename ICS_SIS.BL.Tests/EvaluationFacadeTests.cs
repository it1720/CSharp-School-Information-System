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
using ICS_SIS.BL.Mappers;
using System.Diagnostics;

namespace ICS_SIS.BL.Tests;

public sealed class EvaluationFacadeTests : FacadeTestsBase
{
    private readonly IEvaluationFacade _EvaluationFacadeSUT;

    public EvaluationFacadeTests(ITestOutputHelper output) : base(output)
    {
        _EvaluationFacadeSUT = new EvaluationFacade(UnitOfWorkFactory, EvaluationModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new EvaluationDetailModel()
        {
            Id = Guid.Empty,
            Points = 15,
            Comment = "Great job!",
            StudentId = StudentSeeds.Student1.Id,

            //        ActivityId = ActivitySeeds.LabTest.Id

        };

        await _EvaluationFacadeSUT.SaveAsync(model, ActivitySeeds.LabTest.Id);
    }

    [Fact]
    public async Task GetAll_Evaluations_ContainsSeededEvaluation()
    {

        //act
        var Evaluations = await _EvaluationFacadeSUT.GetAsync();
        var Evaluation = EvaluationModelMapper.MapToListModel(EvaluationSeeds.EvaluationSeedTest);


        //Assert
        DeepAssert.Contains(Evaluation, Evaluations);
    }

    [Fact]
    public async Task GetById_Evaluation_ContainsSeededEvaluation()
    {
        //act
        var Evaluation = await _EvaluationFacadeSUT.GetAsync(EvaluationSeeds.EvaluationSeedTest.Id);

        //Assert
        DeepAssert.Equal(EvaluationModelMapper.MapToDetailModel(EvaluationSeeds.EvaluationSeedTest), Evaluation);
    }



}
