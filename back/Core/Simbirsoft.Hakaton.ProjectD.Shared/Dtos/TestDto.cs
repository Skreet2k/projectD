namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos;

public class TestDto
{
    /// <summary>
    /// Идентификатор записи.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTimeOffset? CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления.
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}