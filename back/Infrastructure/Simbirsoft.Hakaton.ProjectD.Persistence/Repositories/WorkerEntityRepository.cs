using MongoDB.Driver;
using Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;
using Simbirsoft.Hakaton.ProjectD.Domain.Entities.Simualation;

namespace Simbirsoft.Hakaton.ProjectD.Persistence.Repositories;

/// <inheritdoc />
public class WorkerEntityRepository: IGenericRepository<WorkerEntity>
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

    public Task<WorkerEntity> AddAsync(WorkerEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<WorkerEntity> UpdateAsync(WorkerEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}