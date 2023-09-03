using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Application.Hubs;
using Simbirsoft.Hakaton.ProjectD.Application.Services;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Tests;

public class SimulationStarterTests
{
    [Fact]
    public void Test()
    {
        var mapModel = new SimulationModel();

        var service = new SimulationStarter((IHubContext<GameHub, IReceiveGameClient>)new object(), (IMapper)new object());

        service.StartAsync(mapModel, "").GetAwaiter().GetResult();
    }
}