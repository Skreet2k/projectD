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
    Task<Result<UserScoreRecordDto>> GetUserScores(string userId);

    /// <summary>
    /// Получить общие рекорды.
    /// </summary>
    ResultList<UserScoreRecordDto> GetRecordScores();

    /// <summary>
    /// Добавить или обновить рекорд юзера, если он круче
    /// </summary>
    Task<UserScoreRecordDto> AddOrUpdateRecordScoreAsync(UserScoreRecordDto userScoreDto);
}