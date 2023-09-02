using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.DependencyInjection;

/// <summary>
/// Внедрение зависимостей слоя Persistence
/// </summary>
public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddContext(configuration);
        services.AddCollections();
        services.AddRepositories();
    }
}