using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public class FeatureDeadHandler : Handler
{
    public override void HandleRequest(SimulationModel request)
    {
        foreach (var feature in request.Features.ToList())
        {
            if (feature.CurrentHealthPoints > 0)
            {
                continue;
            }

            // Удаляем выполненую задачу.
            request.Features.Remove(feature);

            // Добавляем деньги за выполнение.
            request.Money += feature.Reward;
        }

        _successor?.HandleRequest(request);
    }
}