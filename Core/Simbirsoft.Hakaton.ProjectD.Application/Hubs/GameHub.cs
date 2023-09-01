using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Simbirsoft.Hakaton.ProjectD.Application.Hubs;

/// <summary>
/// Хаб чата.
/// </summary>
[Authorize]
public class GameHub : Hub<IReceiveGameClient>
{
    private readonly IHubContext<GameHub> _myHubContext;

    public GameHub(IHubContext<GameHub> myHubContext)
    {
        _myHubContext = myHubContext;
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine("UserId is " + Context.UserIdentifier);
        return Task.CompletedTask;
    }

    public Task Broadcast()
    {
        return _myHubContext.Clients.All.SendAsync("testMethod", "Привет");
    }

    /// <summary>
    /// Срабатывает при закрытии соединения.
    /// </summary>
    public override Task OnDisconnectedAsync(Exception exception)
    {
        return Task.CompletedTask;
    }
}