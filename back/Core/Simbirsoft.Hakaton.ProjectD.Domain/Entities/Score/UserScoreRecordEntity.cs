namespace Simbirsoft.Hakaton.ProjectD.Domain.Entities.Score;

/// <summary>
/// Рекорды пользователя.
/// </summary>
public class UserScoreRecordEntity : BaseEntity
{
    /// <summary>
    /// ИД юзера.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// Имя юзера.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// ИД уровня.
    /// </summary>
    public string LevelId { get; set; }

    /// <summary>
    /// Имя уровня.
    /// </summary>
    public string LevelName { get; set; }

    /// <summary>
    /// Убитые фитчи.
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Заработанные деньги.
    /// </summary>
    public int TotalMoney { get; set; }

    /// <summary>
    /// Закрыто волн.
    /// </summary>
    public int WavesCleared { get; set; }
}