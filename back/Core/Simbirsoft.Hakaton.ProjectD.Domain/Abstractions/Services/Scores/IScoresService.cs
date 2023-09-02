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
    /// <returns></returns>
    Task<ResultList<ScoreRecordDto>> GetUserScores(string userId);

    /// <summary>
    /// Получить общую статистику по уровню.
    /// </summary>
    /// <param name="levelId"></param>
    /// <returns></returns>
    Task<ResultList<UserScoreRecordDto>> GetLevelScores(string levelId, string userId = "");

    /// <summary>
    /// Получить общие рекорды.
    /// </summary>
    /// <returns></returns>
    Task<ResultList<UserScoreRecordDto>> GetRecordScores(string userId = "");
}