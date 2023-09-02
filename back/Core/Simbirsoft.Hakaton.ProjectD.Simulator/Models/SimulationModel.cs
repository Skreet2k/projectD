using System.Text.Json.Serialization;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationModel
{
    public List<CoordinateDto> Path { get; set; }
    
    public SimulationConfiguration Configuration { get; set; }
    
    public  CustomerModel Customer { get; set; }
    
    public List<WorkerModel> Workers { get; set; }

    public List<FeatureModel> Features { get; set; }
    
    [JsonIgnore]
    public CancellationTokenSource CancellationTokenSource { get; set; }
}