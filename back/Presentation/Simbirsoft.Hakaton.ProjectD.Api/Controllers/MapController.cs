using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class MapController : ControllerBase
{
    private readonly IMapGenerator _generator;

    public MapController(IMapGenerator generator)
    {
        _generator = generator;
    }

    [HttpGet]
    public async Task<Result<MapDto>> Get([FromQuery] byte width, byte height, byte startX, byte startY, byte finishX,
        byte finishY)
    {
        return await _generator.GenerateMapAsync(width, height, startX, startY, finishX, finishY);
    }
}