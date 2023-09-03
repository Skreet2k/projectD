namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

/// <summary>
/// Настройки игры.
/// </summary>
public class GameConfiguration
{
    /// <summary>
    /// Секция по умолчанию.
    /// </summary>
    public const string DefaultSection = nameof(GameConfiguration);

    /// <summary>
    /// Настройки волн.
    /// </summary>
    public WaveConfiguration WaveConfiguration { get; set; }

    /// <summary>
    /// Настройки фич.
    /// </summary>
    public FeatureConfiguration FeatureConfiguration { get; set; }

    /// <summary>
    /// Ширина карты.
    /// </summary>
    public int MapWidth { get; set; }

    /// <summary>
    /// Высота карты.
    /// </summary>
    public int MapHeight { get; set; }

    /// <summary>
    /// Бесконечный уровень.
    /// </summary>
    public bool IsEndlessLevel { get; set; }

    /// <summary>
    /// Количество тиков между спавном фич.
    /// </summary>
    public int TicksToSpawn { get; set; }

    /// <summary>
    /// Количество миллисекунд междду тиками.
    /// </summary>
    public int MillisecondsToTick { get; set; }

    /// <summary>
    /// Стартовый капитал.
    /// </summary>
    public int StartMoney { get; set; }

    /// <summary>
    /// Коэффициент вертикальных стен генератора. Обратная зависимость.
    /// </summary>
    public int KVertical { get; set; }

    /// <summary>
    /// Коэффициент горизонтальных стен генератора. Обратная зависимость.
    /// </summary>
    public int KHorizontal { get; set; }
}

/// <summary>
/// Конфигурация волн.
/// </summary>
public class WaveConfiguration
{
    /// <summary>
    /// Количество фичей в волне.
    /// </summary>
    public int WaveCapacity { get; set; }

    /// <summary>
    /// Модификатор скорости волны.
    /// </summary>
    public double WaveSpeedModifier { get; set; }

    /// <summary>
    /// Модификатор здоровья волны.
    /// </summary>
    public double WaveHealthModifier { get; set; }

    /// <summary>
    /// Модификатор награды волны.
    /// </summary>
    public double WaveRewardModifier { get; set; }

    /// <summary>
    /// Модификатор очков волны.
    /// </summary>
    public double WaveScoreModifier { get; set; }
}

/// <summary>
/// Настройка фич.
/// </summary>
public class FeatureConfiguration
{
    /// <summary>
    /// Начальные ХП.
    /// </summary>
    public int InitHealth { get; set; }

    /// <summary>
    /// Начальная скорость.
    /// </summary>
    public int InitSpeed { get; set; }

    /// <summary>
    /// Начальная награда.
    /// </summary>
    public int InitReward { get; set; }
}