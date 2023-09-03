using MongoDB.Driver;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Score;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Repositories;

/// <inheritdoc />
public class ScoreRepository : IGenericRepository<UserScoreRecordEntity>
{
    private const string LevelName = "Сделать банковское приложение с помощью ChatGPT";
    private const string LevelId = "64f398d3d85d555bcf3e78e0";

    private readonly IMongoCollection<UserScoreRecordEntity> _collection;

    public ScoreRepository(IMongoCollection<UserScoreRecordEntity> collection)
    {
        _collection = collection;
    }

    /// <inheritdoc />
    public IQueryable<UserScoreRecordEntity> Get()
    {
        return _collection.AsQueryable();
    }

    public async Task<UserScoreRecordEntity> AddAsync(UserScoreRecordEntity entity)
    {
        entity.CreatedAt = DateTimeOffset.Now;
        entity.LevelName = LevelName;
        entity.LevelId = LevelId;

        await _collection.InsertOneAsync(entity);

        return entity;
    }

    public async Task<UserScoreRecordEntity> UpdateAsync(UserScoreRecordEntity entity)
    {
        var update = Builders<UserScoreRecordEntity>.Update
            .Set(e => e.UpdatedAt, DateTimeOffset.Now)
            .Set(e => e.Score, entity.Score)
            .Set(e => e.WavesCleared, entity.WavesCleared)
            .Set(e => e.TotalMoney, entity.TotalMoney);

        await _collection.UpdateOneAsync(e => e.Id == entity.Id, update);

        return entity;
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}