using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Simulator.Abstractions;
using Simbirsoft.Hakaton.ProjectD.Simulator.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Services;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение сервисов.
/// </summary>
public static class ServicesInjection
{
    /// <summary>
    /// Внедрение сервисов.
    /// </summary>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<IWorkersService, WorkerService>();
        services.AddScoped<IScoresService, ScoresService>();

        services.AddScoped<IMapGenerator, MapGenerator>();

        services.AddScoped<ISimulationSessionService, SimulationSessionService>();
        services.AddScoped<MapServices>();
        services.AddScoped<ISimulationStarter, SimulationStarter>();
    }
}