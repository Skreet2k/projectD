﻿using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Workers;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualtion;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Workers;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class WorkerService : IWorkersService
{
    private readonly IMapper _mapper;

    private readonly IGenericRepository<WorkerEntity> _workerRepository;

    public WorkerService(IGenericRepository<WorkerEntity> workerRepository, IMapper mapper)
    {
        _workerRepository = workerRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public ResultList<WorkerDto> GetWorkers()
    {
        var entities = _workerRepository.Get();

        var models = _mapper.ProjectTo<WorkerDto>(entities).ToList();

        return new ResultList<WorkerDto>(models);
    }
}