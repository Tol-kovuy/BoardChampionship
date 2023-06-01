using BoardChampionship.DAL.Entities;

namespace BoardChampionship.Models;

public class TeamViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<PlayerViewModel> Players { get; set; }
}
