using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class ScoresController : ControllerBase
{
    private readonly IScoresService _scoresService;

    public ScoresController(IScoresService scoresService)
    {
        _scoresService = scoresService;
    }

    [HttpGet("user")]
    public async Task<ResultList<ScoreRecordDto>> GetScores()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        return await _scoresService.GetUserScores(userId);
    }

    [HttpGet("level")]
    public async Task<ResultList<UserScoreRecordDto>> GetLevelScores([FromQuery] string levelId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _scoresService.GetLevelScores(levelId, userId);
    }

    [HttpGet("record")]
    public async Task<ResultList<UserScoreRecordDto>> GetRecordScores()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return await _scoresService.GetRecordScores(userId);
    }
}