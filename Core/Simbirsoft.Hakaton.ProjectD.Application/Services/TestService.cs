using AutoMapper;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

public class TestService : ITestService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<TestEntity> _repository;

    public TestService(IGenericRepository<TestEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public ResultList<TestDto> Get()
    {
        var query = _repository.Get().ProjectTo<TestDto>(_mapper.ConfigurationProvider);
        return new ResultList<TestDto>(query);
    }

    /// <inheritdoc />
    public async Task<Result<TestDto>> AddAsync(TestDto dto)
    {
        var entity = _mapper.Map<TestEntity>(dto);

        entity = await _repository.AddAsync(entity);

        var result = _mapper.Map<TestDto>(entity);

        return new Result<TestDto>(result);
    }
}