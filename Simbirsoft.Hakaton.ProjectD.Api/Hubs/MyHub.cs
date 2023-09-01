using Microsoft.AspNetCore.SignalR;

namespace Simbirsoft.Hakaton.ProjectD.Api.Hubs;

public class MyHub : Hub
{
    public Task Broadcast()
    {
        return Clients.All.SendAsync("test", new[] { "hello", "world" });
    }
}