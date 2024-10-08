using Shared.Models;
using Data.Repository;

namespace Analysis.Controller;
public class DataAnalyzer : IDataAnalyzer
{
    private readonly IMatchDataRepository _repository;

    public DataAnalyzer(IMatchDataRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<MatchData> BothTeamsScore()
    {
        return _repository.GetMatchData().Result.Where(x => x.HomeWin > 0.35 && x.AwayWin > 0.35 && x.OverTwoGoals > 0.6);
    }

    public IEnumerable<MatchData> Draw()
    {
        return _repository.GetMatchData().Result.Where(x => x.Draw > 0.35 && x.HomeWin < 0.37 && x.AwayWin < 0.37 && x.UnderTwoGoals > 0.65 && x.UnderThreeGoals > 0.75);
    }

    public IEnumerable<MatchData> OverThreeGoals()
    {
        return _repository.GetMatchData().Result.Where(x => x.OverThreeGoals > 0.65);
    }

    public IEnumerable<MatchData> OverTwoGoals()
    {
        return _repository.GetMatchData().Result.Where(x => x.HomeWin > 0.35 && x.AwayWin > 0.35 && x.OverTwoGoals > 0.65);
    }

    public IEnumerable<MatchData> StraightWin()
    {
        return _repository.GetMatchData().Result.Where(x => x.HomeWin > 0.65 || x.AwayWin > 0.67);
    }

    public IEnumerable<MatchData> UnderTwoGoals()
    {
        return _repository.GetMatchData().Result.Where(x => x.HomeWin < 0.37 && x.AwayWin < 0.37 && x.UnderTwoGoals > 0.65);
    }
}