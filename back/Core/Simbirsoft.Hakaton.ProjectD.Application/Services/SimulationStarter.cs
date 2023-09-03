using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Application.Hubs;
using Simbirsoft.Hakaton.ProjectD.Simulator.Abstractions;
using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class SimulationStarter : ISimulationStarter
{
    private readonly IHubContext<GameHub, IReceiveGameClient> _hubContext;

    public SimulationStarter(IHubContext<GameHub, IReceiveGameClient> hubContext)
    {
        _hubContext = hubContext;
    }

    /// <inheritdoc />
    public async Task StartAsync(SimulationModel mapModel, string userId)
    {
        var customerHandler = new CustomerHandler();
        var featureHandler = new FeatureHandler();
        var workerHandler = new WorkerHandler();
        var deadHandler = new FeatureDeadHandler();

        customerHandler.SetSuccessor(featureHandler);
        featureHandler.SetSuccessor(workerHandler);
        featureHandler.SetSuccessor(deadHandler);

        while (!mapModel.IsBurtnOut)
        {
            if (mapModel.CancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            customerHandler.HandleRequest(mapModel);
            await _hubContext.Clients.User(userId).UpdateClient(mapModel);
            await Task.Delay(mapModel.Configuration.MillisecondsToTick);
        }
    }
}