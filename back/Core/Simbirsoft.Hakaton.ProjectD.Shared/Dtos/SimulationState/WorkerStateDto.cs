using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;

public class WorkerStateDto
{
    public string Id { get; set; }

    public CoordinateDto Coordinate { get; set; }

    public string TargetId { get; set; }
}