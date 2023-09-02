using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class CustomerModel
{
    /// <summary>
    /// Запас фичей.
    /// </summary>
    private readonly List<FeatureModel> _featuresPool;

    /// <summary>
    /// Живые фичи на уровне.
    /// </summary>
    private readonly List<FeatureModel> _features;

    /// <summary>
    /// Количество тиков, через которое должна спавниться таска.
    /// </summary>
    private int TicksToSpawn { get; }

    /// <summary>
    /// Координата начала пути.
    /// </summary>
    private CoordinateDto StartCoordinate { get; }

    private int _currentTick { get; set; }

    public CustomerModel(SimulationModel simulation, List<FeatureModel> levelFeatures)
    {
        _features = simulation.Features;
        _featuresPool = levelFeatures;
        StartCoordinate = simulation.Path[0];
        TicksToSpawn = simulation.Configuration.TicksToSpawn;
    }

    /// <summary>
    /// Тут всё, что делает Заказчик каждый тик.
    /// </summary>
    public void MakeLifeHarder()
    {
        // Каждый тик смотрим, прошло ли нужное количество тиков с прошлого спауна.
        _currentTick++;
        if (_currentTick == TicksToSpawn)
        {
            // Если прошло, обнуляем счётчик тиков и спауним
            _currentTick = 0;
            SpawnFeature();
        }
    }

    /// <summary>
    /// Спауним фичу.
    /// </summary>
    private void SpawnFeature()
    {
        // Берём фичу из начала пула и удаляем её из пула.
        var feature = _featuresPool.FirstOrDefault();
        if (feature == null)
            return;
        
        _featuresPool.Remove(feature);

        // Задаём стартовую координату фичи.
        feature.CurrentCoordinate = new CoordinateDto { X = StartCoordinate.X, Y = StartCoordinate.Y };

        // Добавляем фичу на карту.
        _features.Add(feature);
    }
}