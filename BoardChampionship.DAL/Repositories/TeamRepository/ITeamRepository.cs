using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;

namespace BoardChampionship.DAL.Repositories.TeamRepository;

public interface ITeamRepository : IBaseRepository<Team>
{
    Team GetByName(string name);
}