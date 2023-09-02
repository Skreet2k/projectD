namespace Simbirsoft.Hakaton.ProjectD.Shared.Dtos.Scores;

public class UserScoreRecordDto
{
    public string UserId { get; set; }

    public string UserName { get; set; }
    
    public string LevelId { get; set; }

    public string LevelName { get; set; }

    public int Score { get; set; }
}