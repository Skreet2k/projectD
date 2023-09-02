using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class ScoresService : IScoresService
{
    /// <inheritdoc />
    public async Task<ResultList<ScoreRecordDto>> GetUserScores(string userId)
    {
        var result = new List<ScoreRecordDto>
        {
            new()
            {
                LevelId = "5C907330-17FA-454D-BA0B-B7B9C79F226E",
                LevelName = "Уровень 1",
                Score = 1352,
                Won = true
            },
            new()
            {
                LevelId = "6555FA01-99C2-4179-BB01-2B091BCDFA17",
                LevelName = "Уровень 2",
                Score = 6382,
                Won = true
            },
            new()
            {
                LevelId = "A5A51A59-5B36-4AD4-9BF0-B2A400039F0C",
                LevelName = "Уровень 3",
                Score = 523,
                Won = false
            }
        };

        return new ResultList<ScoreRecordDto>(result);
    }

    /// <inheritdoc />
    public async Task<ResultList<UserScoreRecordDto>> GetLevelScores(string levelId, string userId = null)
    {
        var result = new List<UserScoreRecordDto>
        {
            new()
            {
                LevelId = "6555FA01-99C2-4179-BB01-2B091BCDFA17",
                LevelName = "Уровень 2",
                UserId = userId,
                UserName = "Я",
                Score = 6382
            },
            new()
            {
                LevelId = "6555FA01-99C2-4179-BB01-2B091BCDFA17",
                LevelName = "Уровень 2",
                UserId = "7271000C-8275-4030-A786-D1BEF714C34E",
                UserName = "OtherUser1",
                Score = 5432
            },
            new()
            {
                LevelId = "6555FA01-99C2-4179-BB01-2B091BCDFA17",
                LevelName = "Уровень 2",
                UserId = "7271000C-8275-4030-A786-D1BEF714C32E",
                UserName = "OtherUser2",
                Score = 4261
            }
        };

        return new ResultList<UserScoreRecordDto>(result);
    }

    /// <inheritdoc />
    public async Task<ResultList<UserScoreRecordDto>> GetRecordScores(string userId = null)
    {
        var result = new List<UserScoreRecordDto>
        {
            new()
            {
                LevelId = "5C907330-17FA-454D-BA0B-B7B9C79F226E",
                LevelName = "Уровень 1",
                UserId = "7271000C-8275-4030-A786-D1BEF714C34E",
                UserName = "OtherUser1",
                Score = 6436
            },
            new()
            {
                LevelId = "6555FA01-99C2-4179-BB01-2B091BCDFA17",
                LevelName = "Уровень 2",
                UserId = userId,
                UserName = "Я",
                Score = 6382
            },
            new()
            {
                LevelId = "A5A51A59-5B36-4AD4-9BF0-B2A400039F0C",
                LevelName = "Уровень 3",
                UserId = "7271000C-8275-4030-A786-D1BEF714C32E",
                UserName = "OtherUser2",
                Score = 6645
            }
        };

        return new ResultList<UserScoreRecordDto>(result);
    }
}