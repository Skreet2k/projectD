using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;
using Simbirsoft.Hakaton.ProjectD.Persistence.Context;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.DependencyInjection;

/// <summary>
/// Внедрение контекста
/// </summary>
public static class ContextInjection
{
    public static void AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MongoDbContext>();
        services.AddOptions<MongoDbConfig>().Bind(configuration.GetSection(MongoDbConfig.DefaultSection));
    }
}