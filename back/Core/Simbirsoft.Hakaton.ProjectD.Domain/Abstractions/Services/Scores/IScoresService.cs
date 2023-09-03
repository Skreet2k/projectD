using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;

/// <summary>
/// Работа со статистикой пользователя.
/// </summary>
public interface IScoresService
{
    /// <summary>
    /// Получить статистику пользователя по уровням.
    /// </summary>
    Task<ResultList<ScoreRecordDto>> GetUserScores(string userId);

    /// <summary>
    /// Получить общую статистику по уровню.
    /// </summary>
    Task<ResultList<UserScoreRecordDto>> GetLevelScores(string levelId, string userId = null);

    /// <summary>
    /// Получить общие рекорды.
    /// </summary>
    Task<ResultList<UserScoreRecordDto>> GetRecordScores(string userId = null);

    /// <summary>
    /// Добавить или обновить рекорд юзера, если он круче
    /// </summary>
    Task AddOrUpdateRecordScoreAsync(string userId, string levelId, int score, int totalMoney);
}