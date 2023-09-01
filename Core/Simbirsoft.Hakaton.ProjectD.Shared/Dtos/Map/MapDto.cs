namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

/// <summary>
/// Модель карты.
/// </summary>
public class MapDto
{
    /// <summary>
    /// Ширина карты.
    /// </summary>
    public byte Width { get; set; }

    /// <summary>
    /// Высота карты.
    /// </summary>
    public byte Height { get; set; }

    /// <summary>
    /// Путь по карте.
    /// </summary>
    public List<CoordinateDto> Path { get; set; } = new();
}