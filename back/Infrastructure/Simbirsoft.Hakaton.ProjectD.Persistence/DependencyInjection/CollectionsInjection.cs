using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Score;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualtion;
using Simbirsoft.Hakaton.ProjectD.Persistence.Context;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.DependencyInjection;

/// <summary>
/// Внедрение коллекций.
/// </summary>
public static class CollectionsInjection
{
    public static void AddCollections(this IServiceCollection services)
    {
        services.AddScoped(sp => sp.GetRequiredService<MongoDbContext>().GetCollection<BaseEntity>());
        services.AddScoped(sp => sp.GetRequiredService<MongoDbContext>().GetCollection<TestEntity>());
        services.AddScoped(sp => sp.GetRequiredService<MongoDbContext>().GetCollection<WorkerEntity>());
        services.AddScoped(sp => sp.GetRequiredService<MongoDbContext>().GetCollection<UserScoreRecordEntity>());
    }
}