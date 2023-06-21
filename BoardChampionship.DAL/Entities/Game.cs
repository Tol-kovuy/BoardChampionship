using BoardChampionship.DAL.Enums;

namespace BoardChampionship.DAL.Entities;

public class Game
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual RoundNumberType Raund { get; set; }
    public virtual MatchResult Result { get; set; }
    public virtual ICollection<Team> Teams { get; set; }
}
