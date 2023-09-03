using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Score;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;

namespace Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Score;

/// <summary>
/// Профиль рекордов пользователя.
/// </summary>
public class UserScoreProfile : Profile
{
    public UserScoreProfile()
    {
        CreateMap<UserScoreRecordEntity, UserScoreRecordDto>()
            .ForMember(d => d.LevelId, opt => opt.MapFrom(s => s.LevelId))
            .ForMember(d => d.LevelName, opt => opt.MapFrom(s => s.LevelName))
            .ForMember(d => d.TotalMoney, opt => opt.MapFrom(s => s.TotalMoney))
            .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
            .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
            .ForMember(d => d.Score, opt => opt.MapFrom(s => s.Score));
    }
}