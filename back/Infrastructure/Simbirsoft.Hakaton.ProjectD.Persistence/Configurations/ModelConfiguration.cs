namespace Simbirsoft.Hakaton.ProjectD.Persistence.Configurations;

/// <summary>
/// Конфигурация моделей БД.
/// </summary>
public static class ModelConfiguration
{
    private static bool _configured;

    public static void Configure()
    {
        if (!_configured)
        {
            AddConfigurations();
            _configured = true;
        }
    }

    private static void AddConfigurations()
    {
        TestEntityConfiguration.Add();
        WorkerEntityConfiguration.Add();
    }
}