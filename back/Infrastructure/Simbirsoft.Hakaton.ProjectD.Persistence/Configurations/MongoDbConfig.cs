namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

public class MongoDbConfig
{
    public const string DefaultSection = nameof(MongoDbConfig);
    public string Name { get; init; }
    public string ConnectionString { get; init; }
}