namespace BoardChampionship.DAL.Entities;

public class Winner
{
    public int Id { get; set; }
    public int WinnerTeamId { get; set; }
    public string Name { get; set; }
    public virtual Team WinnerTeam { get; set; }
}
