using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;

/// <summary>
/// Сервис для работы с Работниками.
/// </summary>
public interface IWorkersService
{
    /// <summary>
    /// Получить список доступных Работников.
    /// </summary>
    /// <returns>Список работников.</returns>
    Task<ResultList<WorkerDto>> GetWorkersAsync();
}