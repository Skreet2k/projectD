using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Simulator.Services;

public class MapServices
{
    private readonly IMapGenerator _mapGenerator;

    public MapServices(IMapGenerator mapGenerator)
    {
        _mapGenerator = mapGenerator;
    }

    public async Task<MapDto> GetMapAsync()
    {
        var map = await _mapGenerator.GenerateMapAsync(8, 6, 0, 3, 8, 5);

        return map.Content;
    }
}