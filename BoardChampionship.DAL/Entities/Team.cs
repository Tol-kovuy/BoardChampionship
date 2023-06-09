﻿namespace BoardChampionship.DAL.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Player> Players { get; set; }
}
