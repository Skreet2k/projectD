using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles;

/// <summary>
/// Настройки маппинга для моделей чата.
/// </summary>
public class TestMapper : Profile
{
    public TestMapper()
    {
        CreateMap<TestEntity, TestDto>()
            .ForMember(x => x.Id, m => m.MapFrom(e => e.Id))
            .ForMember(x => x.CreatedAt, m => m.MapFrom(e => e.CreatedAt))
            .ForMember(x => x.UpdatedAt, m => m.MapFrom(e => e.UpdatedAt))
            .ReverseMap();
    }
}