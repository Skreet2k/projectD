using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Map;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Map;

/// <summary>
/// Профиль маппинга карты.
/// </summary>
public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<CoordinateEntity, CoordinateDto>()
            .ReverseMap();

        CreateMap<MapEntity, MapDto>()
            .ReverseMap();
    }
}