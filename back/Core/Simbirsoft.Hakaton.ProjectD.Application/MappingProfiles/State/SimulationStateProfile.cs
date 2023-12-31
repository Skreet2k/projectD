﻿using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.SimulationState;
using Simbirsoft.Hakaton.ProjectD.Simulator.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.State;

/// <summary>
/// Профиль мапинга для стейта.
/// </summary>
public class SimulationStateProfile : Profile
{
    public SimulationStateProfile()
    {
        CreateMap<SimulationModel, SimulationStateDto>()
            .ForMember(d => d.CurrentHealthPoints, opt => opt.MapFrom(s => s.CurrentHealthPoints))
            .ForMember(d => d.Features, opt => opt.MapFrom(s => s.Features))
            .ForMember(d => d.Money, opt => opt.MapFrom(s => s.Money))
            .ForMember(d => d.TotalMoney, opt => opt.MapFrom(s => s.TotalMoney))
            .ForMember(d => d.Workers, opt => opt.MapFrom(s => s.Workers))
            .ForMember(d => d.MaximumHealthPoints, opt => opt.MapFrom(s => s.MaximumHealthPoints))
            .ForMember(d => d.FeaturesCompleted, opt => opt.MapFrom(s => s.FeaturesCompleted))
            .ForMember(d => d.Score, opt => opt.MapFrom(s => s.Score))
            .ForMember(d => d.CurrentWave, opt => opt.MapFrom(s => s.CurrentWave));
    }
}