namespace BoardChampionship.DAL.Entities;

public class Winner
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
    public virtual ICollection<MatchResult> Results { get; set; }
}
