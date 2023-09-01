using Simbirsoft.Hakaton.ProjectD.Shared.Dtos;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services;

public interface ITestService
{
    /// <summary>
    /// Получение.
    /// </summary>
    ResultList<TestDto> Get();

    /// <summary>
    /// Добавление.
    /// </summary>
    Task<Result<TestDto>> AddAsync(TestDto dto);
}