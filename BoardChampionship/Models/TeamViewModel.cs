using BoardChampionship.DAL.Entities;

namespace BoardChampionship.Models;

public class TeamViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GameId { get; set; }
    public GameViewModel Game { get; set; }
    public IList<PlayerViewModel> Players { get; set; }
}
