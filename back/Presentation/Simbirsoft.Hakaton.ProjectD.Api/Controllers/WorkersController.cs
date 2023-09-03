using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class WorkersController : ControllerBase
{
    private readonly IWorkersService _workersService;

    public WorkersController(IWorkersService workersService)
    {
        _workersService = workersService;
    }

    [HttpGet]
    public ResultList<WorkerDto> GetWorkers()
    {
        return _workersService.GetWorkers();
    }
}