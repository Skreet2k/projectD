using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Map;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Score;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.State;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles.Workers;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение зависимостей слоя Application.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Внедрение зависимостей слоя Application.
    /// </summary>
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(typeof(TestMapper));
            cfg.AddProfile(typeof(MapProfile));
            cfg.AddProfile(typeof(StateProfile));
            cfg.AddProfile(typeof(WorkerProfile));
            cfg.AddProfile(typeof(SimulationStateProfile));
            cfg.AddProfile(typeof(UserScoreProfile));
        });
        mapperConfiguration.AssertConfigurationIsValid();
        services.AddSingleton(mapperConfiguration.CreateMapper());

        services.AddLocalization();
        services.AddServices();
        services.AddValidations();
    }
}