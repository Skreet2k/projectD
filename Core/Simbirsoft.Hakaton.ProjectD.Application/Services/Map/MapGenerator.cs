using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Generators;
using Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Models;
using Simbirsoft.Hakaton.ProjectD.Application.Services.Map.Pathfinders;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services.Map;

public class MapGenerator : IMapGenerator
{
    private static IMapper _mapper;

    public MapGenerator(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<Result<MapDto>> GenerateMapAsync(byte width, byte height, byte startX, byte startY,
        byte finishX, byte finishY)
    {
        if (
            startX > width - 1
            || startY > height - 1
            || finishX > width - 1
            || finishY > width - 1
        )
        {
            return new Result<MapDto>
            {
                ReturnCode = -1, Content = null,
                ErrorMessage = "Координаты начала и конца находятся за пределами карты."
            };
        }

        var maze = await EllerGenerator.GenerateMaze(width, height);

        var path = await GetPathGuaranteed(maze, startX, startY, finishX,
            finishY, 0);

        var map = new MapEntity
        {
            Width = width,
            Height = height,
            Path = path
        };

        var mapModel = _mapper.Map<MapDto>(map);

        return new Result<MapDto>(mapModel);
    }

    /// <summary>
    /// Ну да, костыль, на за 10 проходов-то точно сгенерит.
    /// </summary>
    /// <param name="maze"></param>
    /// <param name="startX"></param>
    /// <param name="startY"></param>
    /// <param name="destX"></param>
    /// <param name="destY"></param>
    /// <param name="counter"></param>
    /// <returns></returns>
    private async Task<List<CoordinateEntity>> GetPathGuaranteed(Maze maze, byte startX, byte startY, byte destX,
        byte destY, int counter)
    {
        List<CoordinateEntity> path;

        try
        {
            path = await CommonPathfinder.FindPath(maze, startX, startY, destX,
                destY);
        }
        catch (Exception e)
        {
            counter++;

            if (counter > 10)
                throw;

            path = await GetPathGuaranteed(maze, startX, startY, destX, destY, counter);
        }

        return path;
    }
}