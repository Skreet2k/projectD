namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;

/// <summary>
/// Модель апдейта сессии.
/// </summary>
public class SimulationStateDto
{
    /// <summary>
    /// Воркеры.
    /// </summary>
    public List<WorkerStateDto> Workers { get; set; }

    /// <summary>
    /// Фитчи.
    /// </summary>
    public List<FeatureStateDto> Features { get; set; }

    /// <summary>
    /// Количество денег.
    /// </summary>
    public int Money { get; set; }
    
    /// <summary>
    /// Количество заработанных денег.
    /// </summary>
    public int TotalMoney { get; set; }

    /// <summary>
    /// Максимальное здоровье.
    /// </summary>
    public int MaximumHealthPoints { get; set; }

    /// <summary>
    /// Текущее здоровье.
    /// </summary>
    public int CurrentHealthPoints { get; set; }

    /// <summary>
    /// Счётчик завершённых фич.
    /// </summary>
    public int FeaturesCompleted { get; set; } = 0;

    /// <summary>
    /// Счёт.
    /// </summary>
    public int Score { get; set; } = 0;
}