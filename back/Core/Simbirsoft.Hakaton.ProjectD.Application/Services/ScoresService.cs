using AutoMapper;
using AutoMapper.QueryableExtensions;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Services.Scores;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Score;
using Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;
using Skreet2k.Common.Models;

namespace Simbirsoft.Hakaton.ProjectD.Application.Services;

/// <inheritdoc />
public class ScoresService : IScoresService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<UserScoreRecordEntity> _repository;


    public ScoresService(IGenericRepository<UserScoreRecordEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<Result<UserScoreRecordDto>> GetUserScores(string userId)
    {
        var score = _repository.Get()
            .Where(s => s.UserId == userId)
            .OrderByDescending(s => s.Score)
            .FirstOrDefault();

        var dto = _mapper.Map<UserScoreRecordDto>(score);

        return new Result<UserScoreRecordDto>(dto);
    }

    /// <inheritdoc />
    public ResultList<UserScoreRecordDto> GetRecordScores()
    {
        var records = _repository.Get().OrderByDescending(x => x.Score).Take(10)
            .ProjectTo<UserScoreRecordDto>(_mapper.ConfigurationProvider).ToList();

        return new ResultList<UserScoreRecordDto>(records);
    }

    /// <inheritdoc />
    public async Task<UserScoreRecordDto> AddOrUpdateRecordScoreAsync(UserScoreRecordDto userScoreDto)
    {
        var record = _repository.Get().FirstOrDefault(x => x.UserId == userScoreDto.UserId);

        if (record == null)
        {
            record = new UserScoreRecordEntity
            {
                Score = userScoreDto.Score,
                UserId = userScoreDto.UserId,
                UserName = userScoreDto.UserName,
                TotalMoney = userScoreDto.TotalMoney,
                WavesCleared = userScoreDto.WavesCleared
            };

            await _repository.AddAsync(record);

            return _mapper.Map<UserScoreRecordDto>(record);
        }

        if (record.Score > userScoreDto.Score)
        {
            return _mapper.Map<UserScoreRecordDto>(record);
        }

        record.Score = userScoreDto.Score;
        record.TotalMoney = userScoreDto.TotalMoney;
        record.WavesCleared = userScoreDto.WavesCleared;

        await _repository.UpdateAsync(record);

        return _mapper.Map<UserScoreRecordDto>(record);
    }
}