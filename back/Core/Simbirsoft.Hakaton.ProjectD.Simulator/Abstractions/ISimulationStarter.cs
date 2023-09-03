using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Abstractions;

/// <summary>
/// Сервис для старта симуляции.
/// </summary>
public interface ISimulationStarter
{
    /// <summary>
    /// Начать симуляцию.
    /// </summary>
    Task StartAsync(SimulationModel mapModel, string userId, string userName);

    /// <summary>
    /// Подготовка к игре.
    /// </summary>
    Task PrepareAsync(SimulationModel mapModel, string userId);
}