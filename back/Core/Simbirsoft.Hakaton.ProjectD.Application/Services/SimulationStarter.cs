using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Application.Hubs;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;
using Simbirsoft.Hakaton.ProjectD.Simulator.Abstractions;
using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class SimulationStarter : ISimulationStarter
{
    private readonly IHubContext<GameHub, IReceiveGameClient> _hubContext;

    private readonly IMapper _mapper;
    private readonly IScoresService _scoresService;

    public SimulationStarter(
        IHubContext<GameHub, IReceiveGameClient> hubContext,
        IMapper mapper,
        IScoresService scoresService)
    {
        _hubContext = hubContext;
        _mapper = mapper;
        _scoresService = scoresService;
    }

    /// <inheritdoc />
    public async Task StartAsync(SimulationModel mapModel, string userId, string userName)
    {
        var customerHandler = new CustomerHandler();
        var featureHandler = new FeatureHandler();
        var workerHandler = new WorkerHandler();
        var deadHandler = new FeatureDeadHandler();

        customerHandler.SetSuccessor(featureHandler);
        featureHandler.SetSuccessor(workerHandler);
        featureHandler.SetSuccessor(deadHandler);

        while (!mapModel.IsBurntOut)
        {
            if (mapModel.CancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            customerHandler.HandleRequest(mapModel);

            var state = _mapper.Map<SimulationStateDto>(mapModel);

            await _hubContext.Clients.User(userId).UpdateClient(state);
            await Task.Delay(mapModel.Configuration.MillisecondsToTick);
        }

        var userScoreDto = new UserScoreRecordDto
        {
            Score = mapModel.Score,
            UserId = userId,
            UserName = userName
        };

        var userScore = await _scoresService.AddOrUpdateRecordScoreAsync(userScoreDto);

        await _hubContext.Clients.User(userId).EndGame(userScore);
    }
}