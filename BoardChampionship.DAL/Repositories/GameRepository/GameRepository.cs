using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;
using Microsoft.EntityFrameworkCore;

namespace BoardChampionship.DAL.Repositories.GameRepository;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(
        AppDbContext context
        )
    {
        _context = context;
    }


    public void Create(Game entity)
    {
        _context.Games.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Game entity)
    {
       _context.Games.Remove(entity);
        _context.SaveChanges();
    }

    public IQueryable<Game> GetAll()
    {
        return _context.Games;
    }

    public Game GetById(int id)
    {
        var game = _context.Games.SingleOrDefault(x => x.Id == id);
        return game;
    }

    public void Update(Game entity)
    {
        _context.Games.Update(entity);
        _context.SaveChanges();
    }
}
