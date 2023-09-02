namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationConfiguration
{
    public int MillisecondsToTick { get; set; } = 100;

    public int TicksToSpawn { get; set; } = 10;
    
    public bool IsEndlessLevel { get; set; }
}