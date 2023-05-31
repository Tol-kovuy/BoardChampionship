using BoardChampionship.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BoardChampionship.DAL;

public class AppDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }

    public AppDbContext(
        DbContextOptions<AppDbContext> options
        )
        : base(options) { }
}
