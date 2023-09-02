using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualation;
using Simbirsoft.Hakaton.ProjectD.Persistence.Repositories;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.DependencyInjection;

/// <summary>
/// Внедрение репозиториев.
/// </summary>
public static class RepositoriesInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGenericRepository<TestEntity>, TestEntityRepository>();
        services.AddScoped<IGenericRepository<WorkerEntity>, WorkerEntityRepository>();
    }
}