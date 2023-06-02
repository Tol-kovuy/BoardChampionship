using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;

namespace BoardChampionship.DAL.Repositories.WinnerRepostory;

public class WinnerRepository : IBaseRepository<Winner>
{
    private readonly AppDbContext _context;

    public WinnerRepository(
        AppDbContext context
        )
    {
        _context = context;
    }

    public void Create(Winner entity)
    {
        _context.Winners.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Winner entity)
    {
        _context.Winners.Remove(entity);
        _context.SaveChanges();
    }

    public IQueryable<Winner> GetAll()
    {
       var winners = _context.Winners;
        return winners;
    }

    public Winner GetById(int id)
    {
        var winner = _context.Winners.FirstOrDefault(x => x.Id == id);
        return winner;
    }

    public void Update(Winner entity)
    {
        _context.Winners.Update(entity);
        _context.SaveChanges();
    }
}
