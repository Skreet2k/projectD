using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;
using Xunit.Abstractions;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class FeatureHandlerTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public FeatureHandlerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var service = new FeatureHandler();

        var model = new SimulationModel
        {
            Path = new List<CoordinateDto>
            {
                new(0, 0), new(1, 1), new(2, 2), new(3, 3),
                new(3, 4),
                new(3, 5)
            },
            Features = new List<FeatureModel>
            {
                new()
                {
                    CurrentCoordinate = new CoordinateDto(0, 0),
                    ProgressPercents = 0,
                    ProgressPerTick = 100,
                    Reward = 10,
                    MaxHealthPoints = 1000,
                    CurrentHealthPoints = 1000
                }
            },
            Workers = new List<WorkerModel> { new() }
        };

        for (var i = 0; i < 140; i++)
        {
            var current = model.Features.FirstOrDefault();

            if (current == null)
            {
                _testOutputHelper.WriteLine(
                    $"Тик {i}, конец игры");
                return;
            }

            _testOutputHelper.WriteLine(
                $"Тик {i}, X: {current.CurrentCoordinate.X}; Y: {current.CurrentCoordinate.Y}, прогресс {current.ProgressPercents}");
            service.HandleRequest(model);
        }

        Assert.Same(model, model);
    }
}