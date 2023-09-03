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

    /// <summary>
    /// Применить нанесённый урон.
    /// </summary>
    /// <param name="damage">Нанесённый урон.</param>
    public void ReceiveDamage(int damage)
    {
        // Вычитаем урон из текущего ХП.
        CurrentHealthPoints -= damage;

        // Если фича опустилась до 0 ХП, он выполняется.
        if (CurrentHealthPoints <= 0)
            OnComplete();
    }

    /// <summary>
    /// Событие завершения фичи.
    /// </summary>
    private void OnComplete()
    {
    }
}