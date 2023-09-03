using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class WorkersController : ControllerBase
{
    private readonly ISimulationSessionService _simulationSessionService;
    private readonly IWorkersService _workersService;

    public WorkersController(IWorkersService workersService, ISimulationSessionService simulationSessionService)
    {
        _workersService = workersService;
        _simulationSessionService = simulationSessionService;
    }

    [HttpGet]
    public ResultList<WorkerDto> GetWorkers()
    {
        return _workersService.GetWorkers();
    }

    /// <summary>
    /// Добавляем работника.
    /// </summary>
    [HttpPost]
    public void AddWorker(WorkerUpsetDto worker)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _simulationSessionService.AddWorker(userId, worker.Id, worker.Coordinate);
    }

    /// <summary>
    /// Удаляем работника.
    /// </summary>
    [HttpDelete]
    public void RemoveWorker(WorkerUpsetDto worker)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _simulationSessionService.RemoveWorker(userId, worker.Id, worker.Coordinate);
    }
}