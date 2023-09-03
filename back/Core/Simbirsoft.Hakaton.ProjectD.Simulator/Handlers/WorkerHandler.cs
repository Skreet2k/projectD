using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

/// <inheritdoc />
public class WorkerHandler : Handler
{
    /// <inheritdoc />
    public override void HandleRequest(SimulationModel request)
    {
        foreach (var worker in request.Workers)
        {
            worker.Do(request.Features);
        }

        Successor?.HandleRequest(request);
    }
}