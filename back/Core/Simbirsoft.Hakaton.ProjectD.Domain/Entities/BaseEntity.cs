namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities;

/// <summary>
/// Родительский класс для сущностей.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}