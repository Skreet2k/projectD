namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;

public class SimulationStateDto
{
    public FeatureStateDto[] FeaturesState { get; set; }

    public WorkerStateDto[] WorkersState { get; set; }

    public int Money { get; set; }

    public int HealthPoints { get; set; }
}