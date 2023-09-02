using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class FeatureModel
{
    public string Id { get; set; }
    public CoordinateDto CurrentCoordinate { get; set; }
    public CoordinateDto NextCoordinate { get; set; }
    public int ProgressPercents { get; set; }
    
    public int CurrentHealthPoints { get; set; }
    public int MaxHealthPoints { get; set; }
    
    public string Name { get; set; }
    
    public int ProgressPerTick { get; set; }
    
    public int Reward { get; set; }
}