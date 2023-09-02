using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationModel
{
    public SimulationConfiguration Configuration { get; set; }
    
    public  CustomerModel Customer { get; set; }
    
    public CoordinateDto[] Path { get; set; }

    public WorkerModel[] Workers { get; set; }

    public List<FeatureModel> Features { get; set; }
}