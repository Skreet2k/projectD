using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public class TowerHandler : Handler
{
    public override void HandleRequest(SimulationModel request)
    {
        foreach (var worker in request.Workers)
        {
            worker.Fire(request.Features);
        }

        _successor?.HandleRequest(request);
    }
}