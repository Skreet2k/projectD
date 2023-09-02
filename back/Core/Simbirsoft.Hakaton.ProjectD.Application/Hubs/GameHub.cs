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

    public override Task OnConnectedAsync()
    {
        Console.WriteLine("UserId is " + Context.UserIdentifier);
        return Task.CompletedTask;
    }

    public async Task<MapDto> CreateSession()
    {
        return await _simulationSessionService.CreateSessionAsync(Context.UserIdentifier);
    }
    
    public async Task StartSession()
    {
        await _simulationSessionService.StartSessionAsync(Context.UserIdentifier);
    }

    public Task Broadcast()
    {
        return _myHubContext.Clients.All.SendAsync("testMethod", "Привет");
    }

    /// <summary>
    /// Срабатывает при закрытии соединения.
    /// </summary>
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await _simulationSessionService.StopSessionAsync(Context.UserIdentifier);
    }
}