using System.Text.Json.Serialization;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Models;

public class SimulationModel
{
    public List<CoordinateDto> Path { get; set; }

    public SimulationConfiguration Configuration { get; set; }

    public CustomerModel Customer { get; set; }

    public List<WorkerModel> Workers { get; set; }

    public List<FeatureModel> Features { get; set; }

    public int Money { get; set; }

    public int MaximumHealthPoints { get; set; }

    public int CurrentHealthPoints { get; set; }

    public int FeaturesCompleted { get; set; }

    public int Score { get; set; }

    /// <summary>
    /// Команда выгорела?
    /// </summary>
    public bool IsBurntOut { get; set; }

    [JsonIgnore] public CancellationTokenSource CancellationTokenSource { get; set; }

    public void AddWorker(WorkerModel worker)
    {
        if (Money < worker.Cost)
        {
            return;
        }

        Money -= worker.Cost;
        Workers.Add(worker);
        MaximumHealthPoints += worker.HealthPoints;
    }

    public void RemoveWorker(WorkerModel worker)
    {
        var workerModel = Workers.FirstOrDefault(x =>
            x.Id == worker.Id && x.Coordinate.X == worker.Coordinate.X && x.Coordinate.Y == worker.Coordinate.Y);

        Workers.Remove(workerModel);
        Money += worker.Cost;
        MaximumHealthPoints -= worker.HealthPoints;

        CheckHealthPoints();
    }

    /// <summary>
    /// Удалить фичу с поля.
    /// </summary>
    /// <param name="featureId">Id фичи.</param>
    public void RemoveFeature(string featureId)
    {
        var feature = Features.FirstOrDefault(x => x.Id == featureId);
        Features.Remove(feature);
    }

    private void CheckHealthPoints()
    {
        if (CurrentHealthPoints > MaximumHealthPoints)
            CurrentHealthPoints = MaximumHealthPoints;
    }

    /// <summary>
    /// Получить урон по психическому здоровью.
    /// </summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        // Отнимает урон из здоровья.
        CurrentHealthPoints -= damage;

        // Если здоровье опустилось до 0, производим соответствующие действия.
        if (CurrentHealthPoints <= 0)
        {
            OnZeroHealthPoints();
        }
    }

    /// <summary>
    /// Обработка ситуации, когда ХП упали до 0.
    /// </summary>
    private void OnZeroHealthPoints()
    {
        // Команда выгорела.
        IsBurntOut = true;
    }

    public void HandleFeatureCompleted(string featureId)
    {
        var feature = Features.FirstOrDefault(x => x.Id == featureId);
        if (feature == null)
        {
            return;
        }

        FeaturesCompleted++;
        Score += CalculateScore();

        Money += feature.Reward;

        RemoveFeature(featureId);
    }

    /// <summary>
    /// Метод подсчёта очков за выполненную фичу.
    /// </summary>
    /// <param name="featuresCompleted"></param>
    /// <returns></returns>
    private int CalculateScore(int featuresCompleted = 1)
    {
        // Вычисление модификаторов.
        double modifiersMultiplier = 1;

        var result = (int)Math.Round(featuresCompleted * modifiersMultiplier);

        return result;
    }
}