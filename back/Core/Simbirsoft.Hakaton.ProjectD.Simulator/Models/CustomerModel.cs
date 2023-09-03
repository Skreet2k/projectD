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

    private readonly SimulationConfiguration _config;
    
    public CustomerModel(SimulationModel simulation, List<FeatureModel> levelFeatures)
    {
        _model = simulation;
        _features = simulation.Features;
        _featuresPool = levelFeatures;
        StartCoordinate = simulation.Path[0];
        _config = simulation.Configuration;
        if (_config.IsEndlessLevel)
        {
            _rand = new Random();
        }
    }

    #region Свойства

    /// <summary>
    /// Счётчик прошедших тиков.
    /// </summary>
    private int CurrentTick { get; set; }

    /// <summary>
    /// Координата начала пути.
    /// </summary>
    private CoordinateDto StartCoordinate { get; }

    #region Настройки волн

    /// <summary>
    /// Текущая волна.
    /// </summary>
    private int CurrentWave
    {
        get { return _model.CurrentWave; }
        set { _model.CurrentWave = value; }
    }

    #endregion

    #endregion

    #region Методы

    /// <summary>
    /// Тут всё, что делает Заказчик каждый тик.
    /// </summary>
    public void MakeLifeHarder()
    {
        // Каждый тик смотрим, прошло ли нужное количество тиков с прошлого спауна.
        CurrentTick++;
        if (CurrentTick == _config.TicksToSpawn)
        {
            // Если прошло, обнуляем счётчик тиков и спауним
            CurrentTick = 0;
            SpawnFeature();
        }
    }

    /// <summary>
    /// Спауним фичу.
    /// </summary>
    private void SpawnFeature()
    {
        if (_config.IsEndlessLevel && _featuresPool.Count == 0)
        {
            CurrentWave++;
            GenerateWavePool();
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
    /// Генерация фичей для волны и размещение их в пулле.
    /// </summary>
    private void GenerateWavePool()
    {
        int taskHealth = (int)Math.Round(20 * (1 + _config.WaveHealthModifier * CurrentWave));

        int taskSpeed = (int)Math.Round(50 * (1 + _config.WaveSpeedModifier * CurrentWave));

        int taskReward = (int)Math.Round(10 * (1 + _config.WaveRewardModifier * CurrentWave));

        for (int i = 0; i < _config.WaveCapacity; i++)
        {
            var feature = new FeatureModel
            {
                Model = _model,
                Id = Guid.NewGuid().ToString(),
                Name = NameHelper.GenerateFeatureName(),
                MaxHealthPoints = taskHealth,
                CurrentHealthPoints = taskHealth,
                ProgressPerTick = taskSpeed,
                Reward = taskReward
            };

            _featuresPool.Add(feature);
        }
    }

    #endregion
}