using Microsoft.Extensions.DependencyInjection;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение локализации.
/// </summary>
public static class LocalizationInjection
{
    /// <summary>
    /// Внедрение локализации.
    /// </summary>
    public static void AddLocalization(this IServiceCollection services)
    {
        // services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
    }
}