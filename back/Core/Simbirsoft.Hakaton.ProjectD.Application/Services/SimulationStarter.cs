using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Application.Hubs;
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

    public SimulationStarter(IHubContext<GameHub, IReceiveGameClient> hubContext, IMapper mapper)
    {
        _hubContext = hubContext;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task StartAsync(SimulationModel mapModel, string userId)
    {
        var customerHandler = new CustomerHandler();
        var featureHandler = new FeatureHandler();
        var workerHandler = new WorkerHandler();

        customerHandler.SetSuccessor(featureHandler);
        featureHandler.SetSuccessor(workerHandler);

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
    }
}