using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;

/// <summary>
/// Модель добавления воркера.
/// </summary>
public class WorkerUpsetDto
{
    /// <summary>
    /// Ид.
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// Координаты
    /// </summary>
    public CoordinateDto Coordinate { get; set; }
}