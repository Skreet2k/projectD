﻿using System.Collections.Concurrent;
using Microsoft.Extensions.Options;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;
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
    private readonly GameConfiguration _gameConfig;

    public SimulationSessionService(
        IMapGenerator mapGenerator,
        ISimulationStarter simulationStarter,
        IWorkersService workersService,
        IOptions<GameConfiguration> gameConfig)
    {
        _mapGenerator = mapGenerator;
        _simulationStarter = simulationStarter;
        _workersService = workersService;
        _gameConfig = gameConfig.Value;
    }

    /// <inheritdoc />
    public async Task<MapDto> CreateSessionAsync(string userId)
    {
        var X = _gameConfig.MapWidth;
        var Y = _gameConfig.MapHeight;

        var rand = new Random();
        var startY = rand.Next(Y);
        var endY = rand.Next(Y);

        var mapResult = await _mapGenerator.GenerateMapAsync((byte)X, (byte)Y, 0, (byte)startY, 7, (byte)endY);

        var levelPool = new List<FeatureModel>();

        var mapModel = new SimulationModel
        {
            Path = mapResult.Content.Path,
            Features = new List<FeatureModel>(),
            Workers = new List<WorkerModel>(),
            Configuration = _gameConfig,
            Money = _gameConfig.StartMoney
        };

        mapModel.Customer = new CustomerModel(mapModel, levelPool);

        mapModel.CancellationTokenSource = new CancellationTokenSource();

        UserSessions.AddOrUpdate(userId, mapModel, (_, _) => mapModel);

        await _simulationStarter.PrepareAsync(mapModel, userId);

        return mapResult.Content;
    }

    /// <inheritdoc />
    public async Task StartSessionAsync(string userId, string userName)
    {
        UserSessions.TryGetValue(userId, out var session);
        await _simulationStarter.StartAsync(session, userId, userName);

        await StopSessionAsync(userId);
    }

    /// <inheritdoc />
    public async Task AddWorkerAsync(string userId, string workerId, CoordinateDto coordinate)
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
            Cost = worker.Cost,
            HealthPoints = worker.HealthPoints
        };

        session.AddWorker(workerModel);

        await _simulationStarter.PrepareAsync(session, userId);
    }

    /// <inheritdoc />
    public async Task RemoveWorkerAsync(string userId, string workerId, CoordinateDto coordinate)
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

        await _simulationStarter.PrepareAsync(session, userId);
    }

    /// <inheritdoc />
    public async Task StopSessionAsync(string userId)
    {
        UserSessions.Remove(userId, out var session);

        if (session?.CancellationTokenSource == null || session.CancellationTokenSource.IsCancellationRequested)
        {
            return;
        }

        await session.CancellationTokenSource.CancelAsync();
    }
}