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
    public async Task<Result<UserScoreRecordDto>> GetScores()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        return await _scoresService.GetUserScores(userId);
    }

    [HttpGet("global")]
    public ResultList<UserScoreRecordDto> GetRecordScores()
    {
        return _scoresService.GetRecordScores();
    }
}