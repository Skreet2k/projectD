using System.Collections.Concurrent;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;
using Simbirsoft.Hakaton.ProjectD.Simulator.Services;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

public class SimulationSessionService
{
    private readonly IMapGenerator _mapGenerator;
    private readonly SimulationStarter _simulationStarter;
    private static readonly ConcurrentDictionary<string, SimulationModel> UserSessions = new();

    public SimulationSessionService(IMapGenerator mapGenerator, SimulationStarter simulationStarter)
    {
        _mapGenerator = mapGenerator;
        _simulationStarter = simulationStarter;
    }

    public async Task<MapDto> CreateSessionAsync(string userId)
    {
        var mapResult = await _mapGenerator.GenerateMapAsync(8, 6, 0, 3, 8, 5);

        var levelPool = new List<FeatureModel>();
        
        var mapModel = new SimulationModel
        {
            Path = mapResult.Content.Path,
            Features = new List<FeatureModel>(),
            Workers = new List<WorkerModel>(), 
            Configuration = new SimulationConfiguration
            {
                IsEndlessLevel = true,
                TicksToSpawn = 5,
                MillisecondsToTick = 200
            }
        };
        mapModel.Customer = new CustomerModel(mapModel, levelPool);

        UserSessions.TryAdd(userId, mapModel);

        return mapResult.Content;
    }

    public async Task StartSessionAsync(string userId)
    {
        UserSessions.TryGetValue(userId, out var session);
        await _simulationStarter.StartAsync(session);
    }
}