namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;

/// <summary>
/// Карта.
/// </summary>
public class MapEntity : BaseEntity
{
    /// <summary>
    /// Длина.
    /// </summary>
    public byte Width { get; set; }

    /// <summary>
    /// Высота.
    /// </summary>
    public byte Height { get; set; }

    /// <summary>
    /// Путь.
    /// </summary>
    public List<CoordinateEntity> Path { get; set; } = new();
}