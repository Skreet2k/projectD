using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class MapModel
{
    public CoordinateDto[] Path { get; set; }

    public WorkerModel[] Workers { get; set; }

    public List<FeatureModel> Features { get; set; }
}