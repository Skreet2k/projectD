﻿using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public class FeatureHandler : Handler
{
    private const int MaxPercent = 100;

    public override void HandleRequest(SimulationModel request)
    {
        foreach (var feature in request.Features.ToList())
        {
            HandleFeature(feature, request.Path, request);

            if (feature.NextCoordinate is null)
            {
                request.Features.Remove(feature);
            }
        }

        _successor?.HandleRequest(request);
    }

    private void HandleFeature(FeatureModel featureModel, List<CoordinateDto> path, SimulationModel request)
    {
        // Заполняем следующую координату
        if (featureModel.NextCoordinate is null)
        {
            featureModel.NextCoordinate = GetNextCoordinate(featureModel.CurrentCoordinate, path);
        }

        // Прибавляем прогресс движения в клетке
        featureModel.ProgressPercents += featureModel.ProgressPerTick;

        // Если вышли за текущую клетку
        if (featureModel.ProgressPercents >= MaxPercent)
        {
            // Следующая координата становится текущей
            featureModel.CurrentCoordinate = featureModel.NextCoordinate;

            // Условие, когда фича переходит с последней клетки в никуда
            if (featureModel.CurrentCoordinate == null)
            {
                FinishPath(featureModel, request);
                return;
            }

            featureModel.NextCoordinate = GetNextCoordinate(featureModel.CurrentCoordinate, path);

            featureModel.ProgressPercents = 0;
        }
    }

    private CoordinateDto GetNextCoordinate(CoordinateDto currentCoordinate, List<CoordinateDto> path)
    {
        for (var index = 0; index < path.Count; index++)
        {
            var coordinate = path[index];

            // Нашли ту же клетку, пропускаем
            if (coordinate.X != currentCoordinate.X || coordinate.Y != currentCoordinate.Y)
            {
                continue;
            }

            if (index + 1 >= path.Count)
            {
                return null;
            }

            return path[index + 1];
        }

        return null;
    }

    /// <summary>
    /// Заканчиваем путь фичи.
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="simulation"></param>
    private void FinishPath(FeatureModel feature, SimulationModel simulation)
    {
        simulation.ReceiveDamage(feature.CurrentHealthPoints);
        simulation.RemoveFeature(feature.Id);
    }
}