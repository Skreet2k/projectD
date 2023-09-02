using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos;
using Simbirsoft.Hakaton.ProjectD.Shared.Helpers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class TestApiController : ControllerBase
{
    private readonly ITestService _testService;

    public TestApiController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet]
    public ResultList<TestDto> Get()
    {
        return _testService.Get();
    }

    [HttpPost]
    public async Task<Result<TestDto>> Post([FromBody] TestDto dto)
    {
        return await _testService.AddAsync(dto);
    }

    [HttpGet("getRandomName")]
    public string GetName()
    {
        return NameHelper.GenerateFeatureName();
    }
}