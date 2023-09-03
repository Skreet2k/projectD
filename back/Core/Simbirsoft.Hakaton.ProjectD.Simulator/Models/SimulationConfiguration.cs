namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationConfiguration
{
    /// <summary>
    /// Количество миллисекунд, через которое происходит тик.
    /// </summary>
    public int MillisecondsToTick { get; set; } = 100;

    /// <summary>
    /// Количество тиков, через которое должна спавниться таска.
    /// </summary>
    public int TicksToSpawn { get; set; } = 2;

    /// <summary>
    /// Признак бесконечного уровня.
    /// </summary>
    public bool IsEndlessLevel { get; set; }

    /// <summary>
    /// Количество фичей в волне.
    /// </summary>
    public int WaveCapacity { get; set; } = 10;

    /// <summary>
    /// Модификатор скорости волны.
    /// </summary>
    public double WaveSpeedModifier { get; set; } = 0.0;

    /// <summary>
    /// Модификатор здоровья волны.
    /// </summary>
    public double WaveHealthModifier { get; set; } = 0.2;

    /// <summary>
    /// Модификатор награды волны.
    /// </summary>
    public double WaveRewardModifier { get; set; } = 0.2;

    /// <summary>
    /// Модификатор очков волны.
    /// </summary>
    public double WaveScoreModifier { get; set; } = 0.2;
}