using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.Services;
using Simbirsoft.Hakaton.ProjectD.Application.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Map;
using Simbirsoft.Hakaton.ProjectD.Simulator.Services;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение сервисов.
/// </summary>
public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();

        services.AddScoped<IMapGenerator, MapGenerator>();

        services.AddScoped<SimulationSessionService>();
        services.AddScoped<MapServices>();
        services.AddScoped<SimulationStarter>();
    }
}