using MongoDB.Driver;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Repositories;

/// <inheritdoc />
public class TestEntityRepository : IGenericRepository<TestEntity>
{
    private readonly IMongoCollection<TestEntity> _collection;

    public TestEntityRepository(IMongoCollection<TestEntity> collection)
    {
        _collection = collection;
    }

    /// <inheritdoc />
    public IQueryable<TestEntity> Get()
    {
        return _collection.AsQueryable();
    }

    /// <inheritdoc />
    public async Task<TestEntity> AddAsync(TestEntity entity)
    {
        entity.CreatedAt = DateTimeOffset.Now;

        await _collection.InsertOneAsync(entity);

        return entity;
    }

    /// <inheritdoc />
    public async Task<TestEntity> UpdateAsync(TestEntity entity)
    {
        var update = Builders<TestEntity>.Update
            .Set(e => e.UpdatedAt, DateTimeOffset.Now);

        await _collection.UpdateOneAsync(e => e.Id == entity.Id, update);

        return entity;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }
}