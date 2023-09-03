using System.Security.Claims;
using System.Threading.Tasks;
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
    public async Task AddWorker(WorkerUpsetDto worker)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _simulationSessionService.AddWorkerAsync(userId, worker.Id, worker.Coordinate);
    }

    /// <summary>
    /// Удаляем работника.
    /// </summary>
    [HttpDelete]
    public async Task RemoveWorker(WorkerUpsetDto worker)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        await _simulationSessionService.RemoveWorkerAsync(userId, worker.Id, worker.Coordinate);
    }
}