using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Helpers;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class CustomerModel
{
    private SimulationModel _model;
    
    /// <summary>
    /// Живые фичи на уровне.
    /// </summary>
    private readonly List<FeatureModel> _features;

    /// <summary>
    /// Запас фичей.
    /// </summary>
    private readonly List<FeatureModel> _featuresPool;

    /// <summary>
    /// ГСЧ.
    /// </summary>
    private readonly Random _rand;

    public CustomerModel(SimulationModel simulation, List<FeatureModel> levelFeatures)
    {
        _model = simulation;
        _features = simulation.Features;
        _featuresPool = levelFeatures;
        StartCoordinate = simulation.Path[0];
        TicksToSpawn = simulation.Configuration.TicksToSpawn;
        IsEndlessGame = simulation.Configuration.IsEndlessLevel;
        if (IsEndlessGame)
        {
            _rand = new Random();
        }
    }

    /// <summary>
    /// Количество тиков, через которое должна спавниться таска.
    /// </summary>
    private int TicksToSpawn { get; }

    /// <summary>
    /// Счётчик прошедших тиков.
    /// </summary>
    private int _currentTick { get; set; }

    /// <summary>
    /// Признак бесконечного уровня.
    /// </summary>
    private bool IsEndlessGame { get; }

    /// <summary>
    /// Координата начала пути.
    /// </summary>
    private CoordinateDto StartCoordinate { get; }

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
        if (IsEndlessGame)
        {
            AddGenericFeature();
        }

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

    /// <summary>
    /// Режим бесконечного пула.
    /// </summary>
    private void AddGenericFeature()
    {
        // Случайно определяем количество ХП 80-130.
        var hp = _rand.Next(21);
        var feature = new FeatureModel
        {
            Model = _model,
            Id = Guid.NewGuid().ToString(),
            Name = NameHelper.GenerateFeatureName(),
            MaxHealthPoints = 10 + hp,
            CurrentHealthPoints = 10 + hp,
            ProgressPerTick = 50
        };

        _featuresPool.Add(feature);
    }
}