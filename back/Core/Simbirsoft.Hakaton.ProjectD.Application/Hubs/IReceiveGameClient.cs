using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Интерфейс для работы с клиентами signalR.
/// </summary>
public interface IReceiveGameClient
{
    Task UpdateClient(SimulationModel model);
}