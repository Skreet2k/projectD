using Simbirsoft.Hakaton.ProjectD.Shared.Enums.Workers;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualation;

/// <summary>
/// Сущность Работника.
/// </summary>
public class WorkerEntity: BaseEntity
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Тип.
    /// </summary>
    public WorkerType Type { get; set; }
    
    /// <summary>
    /// Уровень.
    /// </summary>
    public WorkerLevel Level { get; set; }
    
    /// <summary>
    /// Радиус поражения.
    /// </summary>
    public int Range { get; set; }
    
    /// <summary>
    /// Урон в секунду.
    /// </summary>
    public int Damage { get; set; }
    
    /// <summary>
    /// Стоимость размещения.
    /// </summary>
    public int Cost { get; set; }
}