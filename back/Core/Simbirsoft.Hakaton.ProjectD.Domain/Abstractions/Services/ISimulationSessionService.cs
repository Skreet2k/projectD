﻿using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Map;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;

/// <summary>
/// Сервис для работы с сессиями симуляции.
/// </summary>
public interface ISimulationSessionService
{
    /// <summary>
    /// Создание сессии.
    /// </summary>
    Task<MapDto> CreateSessionAsync(string userId);

    /// <summary>
    /// Старт сессии.
    /// </summary>
    Task StartSessionAsync(string userId, string userName);

    /// <summary>
    /// Добавление воркеров.
    /// </summary>
    Task AddWorkerAsync(string userId, string workerId, CoordinateDto coordinate);

    /// <summary>
    /// Удаление воркеров.
    /// </summary>
    Task RemoveWorkerAsync(string userId, string workerId, CoordinateDto coordinate);

    /// <summary>
    /// Остановка сессии.
    /// </summary>
    Task StopSessionAsync(string userId);
}