using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;
using Microsoft.EntityFrameworkCore;

namespace BoardChampionship.DAL.Repositories.TeamRepository;

public class TeamRepository : ITeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(
        AppDbContext context
        )
    {
        _context = context;
    }

    public void Create(Team entity)
    {
        _context.Teams.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Team entity)
    {
        _context.Teams.Remove(entity);
        _context.SaveChanges();
    }

    public IQueryable<Team> GetAll()
    {
        var teams = _context.Teams.Include(p => p.Players);
        return teams;
    }

    public Team GetById(int id)
    {
        var team = _context.Teams.SingleOrDefault(p => p.Id == id);
        return team;
    }

    public void Update(Team entity)
    {
        _context.Teams.Update(entity);
        _context.SaveChanges();
    }
}
