using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class WorkerModel
{
    public string Id { get; set; }
    
    public CoordinateDto Coordinate { get; set; }
    
    public int Range { get; set; }
    
    public int Power { get; set; }
    
    public FeatureModel CurrentTarget { get; set; }

    public int DamagePerTick { get; set; }
}