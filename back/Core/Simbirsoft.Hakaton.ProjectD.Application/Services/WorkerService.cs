using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;
using Simbirsoft.Hakaton.ProjectD.Shared.Enums.Workers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

public class WorkerService : IWorkersService
{
    /// <inheritdoc />
    public async Task<ResultList<WorkerDto>> GetWorkersAsync()
    {
        var workers = new List<WorkerDto>
        {
            new()
            {
                Id = "1",
                Name = "Backend разработчик",
                Type = WorkerType.BackendDev,
                Cost = 10
            },
            new()
            {
                Id = "2",
                Name = "Frontend разработчик",
                Type = WorkerType.FrontendDev,
                Cost = 10
            }
        };

        return new ResultList<WorkerDto>(workers);
    }
}