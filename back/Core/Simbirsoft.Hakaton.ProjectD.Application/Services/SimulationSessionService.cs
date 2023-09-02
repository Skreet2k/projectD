using System.Collections.Concurrent;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

public class SimulationSessionService
{
    private static readonly ConcurrentDictionary<string, SimulationModel> UserSessions = new();
    private readonly IMapGenerator _mapGenerator;
    private readonly SimulationStarter _simulationStarter;
    private readonly IWorkersService _workersService;

    public SimulationSessionService(
        IMapGenerator mapGenerator, 
        SimulationStarter simulationStarter,
        IWorkersService workersService)
    {
        _mapGenerator = mapGenerator;
        _simulationStarter = simulationStarter;
        _workersService = workersService;
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
            },
            Money = 100
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
    
    public async Task AddWorker(string userId, string workerId, CoordinateDto coordinate)
    {
        UserSessions.TryGetValue(userId, out var session);

        if (session is null)
        {
            return;
        }
        
        var worker = (await _workersService.GetWorkersAsync()).Content.FirstOrDefault(x => x.Id == workerId);

        if (worker == null)
        {
            return;
        }

        var workerModel = new WorkerModel
        {
            Id = worker.Id,
            Coordinate = coordinate,
            DamagePerTick = worker.Damage
        };
        
        session.Workers.Add(workerModel);
    }
    
    public async Task StopSessionAsync(string userId)
    {
        UserSessions.Remove(userId, out var session);

        if (session is not null)
        {
            await session.CancellationTokenSource.CancelAsync();
        }
    }
}