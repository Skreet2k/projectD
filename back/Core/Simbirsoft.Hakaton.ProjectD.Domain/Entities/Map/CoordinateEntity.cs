namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;

public class CoordinateEntity
{
    public CoordinateEntity(byte x, byte y)
    {
        X = x;
        Y = y;
    }

    public byte X { get; }

    public byte Y { get; }
}