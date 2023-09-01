using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.MappingProfiles;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение зависимостей слоя Application.
/// </summary>
public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(TestMapper));

        services.AddLocalization();
        services.AddServices();
        services.AddValidations();
    }
}