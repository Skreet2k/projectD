namespace Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Models;

class Maze
{
    public byte X { get; set; }

    public byte Y { get; set; }
    
    public Cell[] Cells { get; set; }
}