using BoardChampionship.DAL.Entities;

namespace BoardChampionship.Models;

public class WinnerViewModel
{
    public int Id { get; set; }
    public int WinnerTeamId { get; set; }
    public string Name { get; set; }
    public TeamViewModel WinnerTeam { get; set; }
}
