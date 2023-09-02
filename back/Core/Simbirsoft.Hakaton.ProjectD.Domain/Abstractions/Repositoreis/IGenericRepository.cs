namespace Simbirsoft.Hakaton.ProjectD.Domain.Abstractions.Repositoreis;

/// <summary>
/// Репозиторий
/// </summary>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Получение данных.
    /// </summary>
    IQueryable<T> Get();

    /// <summary>
    /// Добавление данных
    /// </summary>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Обновление данных.
    /// </summary>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Удаление данных.
    /// </summary>
    Task DeleteAsync(string id);
}