namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationConfiguration
{
    public int MillisecondsToTick { get; set; } = 1000;

    public int TicksToSpawn { get; set; } = 2;

    public bool IsEndlessLevel { get; set; }
}