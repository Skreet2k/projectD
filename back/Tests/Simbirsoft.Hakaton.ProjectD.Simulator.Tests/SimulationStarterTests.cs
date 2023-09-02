using Simbirsoft.Hakaton.ProjectD.Simulator.Models;
using Simbirsoft.Hakaton.ProjectD.Simulator.Services;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class SimulationStarterTests
{
    [Fact]
    public void Test()
    {
        var mapModel = new SimulationModel();

        var service = new SimulationStarter();

        service.StartAsync(mapModel).GetAwaiter().GetResult();

    }
}