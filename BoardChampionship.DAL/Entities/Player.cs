namespace BoardChampionship.DAL.Entities;

public class Player
{
    public int Id { get; set; }
    public string FirstPlayerName { get; set; }
    public string SecondPlayerName { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
}
