using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Хаб чата.
/// </summary>
[Authorize]
public class GameHub : Hub<IReceiveGameClient>
{
    private readonly ISimulationSessionService _simulationSessionService;

    public GameHub(ISimulationSessionService simulationSessionService)
    {
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
        await _simulationSessionService.StartSessionAsync(Context.UserIdentifier, Context.User.Identity?.Name);
    }

    /// <inheritdoc />
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await _simulationSessionService.StopSessionAsync(Context.UserIdentifier);
    }
}