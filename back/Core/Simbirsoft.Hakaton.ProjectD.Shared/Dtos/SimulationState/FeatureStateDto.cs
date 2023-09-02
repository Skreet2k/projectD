using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;

public class FeatureStateDto
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public int MaxHealthPoints { get; set; }
    
    public int CurrentHealthPoints { get; set; }

    public CoordinateDto CurrentCoordinate { get; set; }
    
    public CoordinateDto NextCoordinage { get; set; }
    
    public int Progress { get; set; }
    
    public bool IsActive { get; set; }
}