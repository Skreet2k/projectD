using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

/// <inheritdoc />
public class CustomerHandler : Handler
{
    /// <inheritdoc />
    public override void HandleRequest(SimulationModel request)
    {
        request.Customer.MakeLifeHarder();

        Successor?.HandleRequest(request);
    }
}