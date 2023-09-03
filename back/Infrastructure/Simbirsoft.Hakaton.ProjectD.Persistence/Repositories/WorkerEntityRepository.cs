using MongoDB.Driver;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualtion;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Repositories;

/// <inheritdoc />
public class WorkerEntityRepository : IGenericRepository<WorkerEntity>
{
    private readonly IMongoCollection<WorkerEntity> _collection;

    public WorkerEntityRepository(IMongoCollection<WorkerEntity> collection)
    {
        _collection = collection;
    }

    /// <inheritdoc />
    public IQueryable<WorkerEntity> Get()
    {
        return _collection.AsQueryable();
    }

    /// <inheritdoc />
    public Task<WorkerEntity> AddAsync(WorkerEntity entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task<WorkerEntity> UpdateAsync(WorkerEntity entity)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}