using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Интерфейс для работы с клиентами SignalR.
/// </summary>
public interface IReceiveGameClient
{
    /// <summary>
    /// Обновление данных клиента.
    /// </summary>
    Task UpdateClient(SimulationStateDto state);

    /// <summary>
    /// Конец игры.
    /// </summary>
    Task EndGame(UserScoreRecordDto state);
}