using BoardChampionship.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardChampionship.Models;

public class PlayerViewModel
{
    public int Id { get; set; }
    public string FirstPlayerName { get; set; }
    public string SecondPlayerName { get; set; }
    public int TeamId { get; set; }
    public  Team Team { get; set; }

    [NotMapped]
    public WinnerViewModel Winner { get; set; }
}
