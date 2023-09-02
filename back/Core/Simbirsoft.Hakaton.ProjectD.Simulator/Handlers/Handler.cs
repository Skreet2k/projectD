using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

public abstract class Handler
{
    protected Handler _successor;

    public void SetSuccessor(Handler successor)
    {
        _successor = successor;
    }

    public abstract void HandleRequest(MapModel request);
}