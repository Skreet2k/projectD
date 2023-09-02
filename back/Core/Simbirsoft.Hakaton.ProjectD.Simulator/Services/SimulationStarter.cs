using Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Services;

public class SimulationStarter
{
    public async Task StartAsync(SimulationModel mapModel)
    {
        var customerHandler = new CustomerHandler();
        var featureHandler = new FeatureHandler();
        var towerHandler = new TowerHandler();
        
        customerHandler.SetSuccessor(featureHandler);
        featureHandler.SetSuccessor(towerHandler);

        while (true)
        {
            customerHandler.HandleRequest(mapModel);
            await Task.Delay(1000);
        }
    }
}