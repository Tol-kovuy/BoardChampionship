using BoardChampionship.DAL.Entities;

namespace BoardChampionship.DAL.Repositories.PlayerRepository;

public class PlayerRepository : IBaseRepository<Player>
{
    private readonly AppDbContext _context; // спросить за readonly

    public PlayerRepository(
        AppDbContext context
        )
    {
        _context = context;
    }

    public void Create(Player entity)
    {
        _context.Players.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Player entity)
    {
        _context.Players.Remove(entity);
        _context.SaveChanges();
    }

    public IQueryable<Player> GetAll()
    {
        var players = _context.Players;
        return players;
    }

    public Player GetById(int id)
    {
        var player = _context.Players.SingleOrDefault(p => p.Id == id);
        return player;
    }

    public void Update(Player entity)
    {
        _context.Players.Update(entity);
        _context.SaveChanges();
    }
}
