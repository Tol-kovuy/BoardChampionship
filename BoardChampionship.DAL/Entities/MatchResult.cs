using BoardChampionship.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardChampionship.DAL.Entities;

public class MatchResult
{
    public int Id { get; set; }
    public int ScoredGoals { get; set; }
    public int ConcededGoals { get; set; }
    [NotMapped]
    public GameResultType GameResult
    {
        get
        {
            if (ScoredGoals > ConcededGoals)
            {
                return GameResultType.Win;
            }
            if (ScoredGoals < ConcededGoals)
            {
                return GameResultType.Lose;
            }
            return GameResultType.Draw;
        }
    }
}
