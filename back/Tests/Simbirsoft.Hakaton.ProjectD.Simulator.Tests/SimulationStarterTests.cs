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

        var mockMapper = new MapperConfiguration(cfg => { });
        var mapper = mockMapper.CreateMapper();

        var service = new SimulationStarter((IHubContext<GameHub, IReceiveGameClient>)new object(), mapper);

        service.StartAsync(mapModel, "").GetAwaiter().GetResult();
    }
}