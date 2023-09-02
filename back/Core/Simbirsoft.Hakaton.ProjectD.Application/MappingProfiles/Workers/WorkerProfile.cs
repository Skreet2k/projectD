using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualation;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Workers;

/// <summary>
/// Профиль маппинга Работников.
/// </summary>
public class WorkerProfile : Profile
{
    public WorkerProfile()
    {
        CreateMap<WorkerEntity, WorkerDto>();
    }
}