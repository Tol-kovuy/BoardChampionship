using BoardChampionship.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardChampionship.DAL.Entities;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ScoredGoals { get; set; }
    public int ConcededGoals { get; set; }
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
    public GamesType GamesNumber { get; set; }
    public int TeamId { get; set; }

    [NotMapped]
    public virtual Team Team { get; set; }
}
