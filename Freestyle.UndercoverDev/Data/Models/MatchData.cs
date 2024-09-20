namespace Data.Models;
public class MatchData
{
    public string? Date { get; set; } = "";
    public string? HomeTeam { get; set; } = "";
    public string? AwayTeam { get; set; } = "";
    public float? HomeWin { get; set; }
    public float? Draw { get; set; }
    public float? AwayWin { get; set; }
    public float? OverOneGoal { get; set; }
    public float? OverTwoGoals { get; set; }
    public float? OverThreeGoals { get; set; }
    public float? OverFourGoals { get; set; }
    public float? UnderOneGoal { get; set; }
    public float? UnderTwoGoals { get; set; }
    public float? UnderThreeGoals { get; set; }
    public float? UnderFourGoals { get; set; }
}