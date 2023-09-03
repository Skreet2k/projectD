using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

/// <inheritdoc />
public class FeatureDeadHandler : Handler
{
    /// <inheritdoc />
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

        Successor?.HandleRequest(request);
    }
}