using Simbirsoft.Hakaton.ProjectD.Shared.Enums.Workers;

namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;

public class WorkerDto
{
    public string Id { get; set; }

    public string Name { get; set; }

    public WorkerType Type { get; set; }

    public int Cost { get; set; }
}