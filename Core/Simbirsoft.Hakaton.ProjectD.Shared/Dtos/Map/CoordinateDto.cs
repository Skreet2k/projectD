namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

/// <summary>
/// Модель координаты.
/// </summary>
public class CoordinateDto
{
    public CoordinateDto(byte x, byte y)
    {
        X = x;
        Y = y;
    }
    
    /// <summary>
    /// Координата по оси X.
    /// </summary>
    public byte X { get; set; }

    /// <summary>
    /// Координата по оси Y.
    /// </summary>
    public byte Y { get; set; }
}