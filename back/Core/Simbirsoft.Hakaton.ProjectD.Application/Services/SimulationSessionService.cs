using System.Collections.Concurrent;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

public class SimulationSessionService
{
    private static readonly ConcurrentDictionary<string, SimulationModel> UserSessions = new();
    private readonly IMapGenerator _mapGenerator;
    private readonly SimulationStarter _simulationStarter;

    public SimulationSessionService(IMapGenerator mapGenerator, SimulationStarter simulationStarter)
    {
        _mapGenerator = mapGenerator;
        _simulationStarter = simulationStarter;
    }

    public async Task<MapDto> CreateSessionAsync(string userId)
    {
        var mapResult = await _mapGenerator.GenerateMapAsync(8, 6, 0, 3, 7, 5);

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
                MillisecondsToTick = 1000
            }
        };
        mapModel.Customer = new CustomerModel(mapModel, levelPool);

        mapModel.CancellationTokenSource = new CancellationTokenSource();

        UserSessions.TryAdd(userId, mapModel);

        return mapResult.Content;
    }

    public async Task StartSessionAsync(string userId)
    {
        UserSessions.TryGetValue(userId, out var session);
        await _simulationStarter.StartAsync(session, userId);
    }

    public async Task StopSessionAsync(string userId)
    {
        UserSessions.Remove(userId, out var session);
        await session.CancellationTokenSource.CancelAsync();
    }
}