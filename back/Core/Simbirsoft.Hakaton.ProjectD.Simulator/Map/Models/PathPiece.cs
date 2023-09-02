namespace Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Models;

internal class PathPiece
{
    public PathPiece(byte x, byte y)
    {
        X = x;
        Y = y;
    }

    public byte X { get; }

    public byte Y { get; }

    public PathPiece Previous { get; set; }
}