namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

/// <summary>
/// Конфиг для подключения.
/// </summary>
public class MongoDbConfig
{
    /// <summary>
    /// Секция по умолчанию.
    /// </summary>
    public const string DefaultSection = nameof(MongoDbConfig);

    /// <summary>
    /// Имя бд.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Строка подключения.
    /// </summary>
    public string ConnectionString { get; init; }
}