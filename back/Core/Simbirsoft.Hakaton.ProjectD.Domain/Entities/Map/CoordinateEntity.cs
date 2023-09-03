namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;

/// <summary>
/// Координата.
/// </summary>
public class CoordinateEntity
{
    public CoordinateEntity(byte x, byte y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// X.
    /// </summary>
    public byte X { get; }

    /// <summary>
    /// Y.
    /// </summary>
    public byte Y { get; }
}