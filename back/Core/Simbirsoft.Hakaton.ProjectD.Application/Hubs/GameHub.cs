using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Application.Services;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Хаб чата.
/// </summary>
[Authorize]
public class GameHub : Hub<IReceiveGameClient>
{
    private readonly IHubContext<GameHub> _myHubContext;

    private readonly SimulationSessionService _simulationSessionService;

    //
    public GameHub(IHubContext<GameHub> myHubContext, SimulationSessionService simulationSessionService)
    {
        _myHubContext = myHubContext;
        _simulationSessionService = simulationSessionService;
    }


    /// <inheritdoc />
    public override Task OnConnectedAsync()
    {
        Console.WriteLine("UserId is " + Context.UserIdentifier);
        return Task.CompletedTask;
    }

    /// <summary>
    /// Создание сессии.
    /// </summary>
    public async Task<MapDto> CreateSession()
    {
        return await _simulationSessionService.CreateSessionAsync(Context.UserIdentifier);
    }

    /// <summary>
    /// Старт сессии.
    /// </summary>
    public async Task StartSession()
    {
        await _simulationSessionService.StartSessionAsync(Context.UserIdentifier);
    }

    /// <inheritdoc />
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await _simulationSessionService.StopSessionAsync(Context.UserIdentifier);
    }
}