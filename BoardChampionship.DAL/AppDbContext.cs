using BoardChampionship.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardChampionship.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    public DbSet<Team> Teams { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options
        )
        : base(options) { }
}
