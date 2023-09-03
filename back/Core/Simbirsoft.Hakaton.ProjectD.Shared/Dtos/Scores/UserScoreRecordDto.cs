namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;

public class UserScoreRecordDto
{
    public string UserId { get; set; }

    public string UserName { get; set; }

    public string LevelId { get; set; }

    public string LevelName { get; set; }

    /// <summary>
    /// Убитые фитчи.
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Заработанные деньги.
    /// </summary>
    public int TotalMoney { get; set; }
}