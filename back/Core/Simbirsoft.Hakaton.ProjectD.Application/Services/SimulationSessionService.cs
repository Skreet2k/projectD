using System.Collections.Concurrent;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Abstractions;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class SimulationSessionService : ISimulationSessionService
{
    private static readonly ConcurrentDictionary<string, SimulationModel> UserSessions = new();
    private readonly IMapGenerator _mapGenerator;
    private readonly ISimulationStarter _simulationStarter;
    private readonly IWorkersService _workersService;

    public SimulationSessionService(
        IMapGenerator mapGenerator,
        ISimulationStarter simulationStarter,
        IWorkersService workersService)
    {
        _mapGenerator = mapGenerator;
        _simulationStarter = simulationStarter;
        _workersService = workersService;
    }

    /// <inheritdoc />
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
                TicksToSpawn = 2,
                MillisecondsToTick = 200
            },
            Money = 100
        };
        mapModel.Customer = new CustomerModel(mapModel, levelPool);
        
        // TODO: тестовая башня.
        mapModel.AddWorker(new WorkerModel
        {
            Id = "1",
            Coordinate = new CoordinateDto { X = 0, Y = 0 },
            Cost = 1,
            Range = 100,
            DamagePerTick = 5,
            HealthPoints = 1000
        });

        mapModel.CancellationTokenSource = new CancellationTokenSource();

        UserSessions.AddOrUpdate(userId, mapModel, (_, _) => mapModel);

        return mapResult.Content;
    }

    /// <inheritdoc />
    public async Task StartSessionAsync(string userId, string userName)
    {
        UserSessions.TryGetValue(userId, out var session);
        await _simulationStarter.StartAsync(session, userId, userName);
    }

    /// <inheritdoc />
    public void AddWorker(string userId, string workerId, CoordinateDto coordinate)
    {
        UserSessions.TryGetValue(userId, out var session);

        if (session is null)
        {
            return;
        }

        var worker = _workersService.GetWorkers().Content.FirstOrDefault(x => x.Id == workerId);

        if (worker == null)
        {
            return;
        }

        var workerModel = new WorkerModel
        {
            Id = worker.Id,
            Coordinate = coordinate,
            DamagePerTick = worker.Damage,
            Range = worker.Range,
            Cost = worker.Cost
        };

        session.AddWorker(workerModel);
    }

    /// <inheritdoc />
    public void RemoveWorker(string userId, string workerId, CoordinateDto coordinate)
    {
        UserSessions.TryGetValue(userId, out var session);

        if (session is null)
        {
            return;
        }

        var worker = _workersService.GetWorkers().Content.FirstOrDefault(x => x.Id == workerId);

        if (worker == null)
        {
            return;
        }

        session.RemoveWorker(new WorkerModel
        {
            Id = workerId,
            Coordinate = new CoordinateDto
            {
                X = coordinate.X,
                Y = coordinate.Y
            }
        });
    }

    /// <inheritdoc />
    public async Task StopSessionAsync(string userId)
    {
        UserSessions.Remove(userId, out var session);

        if (session is not null)
        {
            await session.CancellationTokenSource.CancelAsync();
        }
    }
}