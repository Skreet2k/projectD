using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Handlers;

/// <summary>
/// Обработчик.
/// </summary>
public abstract class Handler
{
    protected Handler Successor;

    /// <summary>
    /// Установить хендлер после успешного выполнения.
    /// </summary>
    /// <param name="successor"></param>
    public void SetSuccessor(Handler successor)
    {
        Successor = successor;
    }

    /// <summary>
    /// Обработать запрос.
    /// </summary>
    public abstract void HandleRequest(SimulationModel request);
}