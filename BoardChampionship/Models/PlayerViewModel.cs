using BoardChampionship.DAL.Entities;

namespace BoardChampionship.Models;

public class PlayerViewModel
{
    public int Id { get; set; }
    public string FirstPlayerName { get; set; }
    public string SecondPlayerName { get; set; }
    public int TeamId { get; set; }
    public virtual Team Team { get; set; }
}
