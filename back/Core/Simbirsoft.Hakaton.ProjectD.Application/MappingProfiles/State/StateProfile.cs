using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.State;

/// <summary>
/// Профиль маппинга состояний.
/// </summary>
public class StateProfile : Profile
{
    public StateProfile()
    {
        CreateMap<WorkerModel, WorkerStateDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Coordinate, opt => opt.MapFrom(s => s.Coordinate))
            .ForMember(d => d.TargetId, opt => opt.MapFrom(s => s.CurrentTarget.Id));

        CreateMap<FeatureModel, FeatureStateDto>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.MaxHealthPoints, opt => opt.MapFrom(s => s.CurrentHealthPoints))
            .ForMember(d => d.CurrentHealthPoints, opt => opt.MapFrom(s => s.CurrentHealthPoints))
            .ForMember(d => d.CurrentCoordinate, opt => opt.MapFrom(s => s.CurrentCoordinate))
            .ForMember(d => d.NextCoordinate, opt => opt.MapFrom(s => s.NextCoordinate))
            .ForMember(d => d.Progress, opt => opt.MapFrom(s => s.ProgressPercents));
    }
}