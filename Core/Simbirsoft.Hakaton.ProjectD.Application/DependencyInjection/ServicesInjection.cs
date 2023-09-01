using Microsoft.Extensions.DependencyInjection;
using Simbirsoft.Hakaton.ProjectD.Application.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;

namespace Simbirsoft.Hakaton.ProjectD.Application.DependencyInjection;

/// <summary>
/// Внедрение сервисов.
/// </summary>
public static class ServicesInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITestService, TestService>();
    }
}