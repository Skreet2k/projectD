namespace Simbirsoft.Hakaton.ProjectD.Simulator.Map.Models;

internal class Cell
{
    public Cell()
    {
    }

    public Cell(byte x, byte y) :
        this()
    {
        X = x;
        Y = y;
    }

    public byte X { get; }
    public byte Y { get; }

    public bool Right { get; set; }
    public bool Bottom { get; set; }
}