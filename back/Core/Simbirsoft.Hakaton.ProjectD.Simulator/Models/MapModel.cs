using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class MapModel
{
    public CoordinateDto[] Path { get; set; }
    
    public WorkerModel[] Workers { get; set; }
    
    public FeatureModel[] Features { get; set; }
}