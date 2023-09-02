using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Интерфейс для работы с клиентами SignalR.
/// </summary>
public interface IReceiveGameClient
{
    /// <summary>
    /// Обновление данных клиента.
    /// </summary>
    Task UpdateClient(SimulationModel model);
}