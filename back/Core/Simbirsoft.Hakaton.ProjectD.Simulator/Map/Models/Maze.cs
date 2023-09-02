namespace Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Models;

internal class Maze
{
    public byte X { get; set; }

    public byte Y { get; set; }

    public Cell[] Cells { get; set; }
}