using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public class CustomerHandler : Handler
{
    public override void HandleRequest(SimulationModel request)
    {
        request.Customer.MakeLifeHarder();

        _successor?.HandleRequest(request);
    }
}