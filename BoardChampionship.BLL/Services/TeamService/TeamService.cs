using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;
using BoardChampionship.DAL.Repositories.TeamRepository;

namespace BoardChampionship.BLL.Services.TeamService;

public class TeamService : ITeamService
{
    private readonly ITeamRepository _teamRepository;
    private readonly IBaseRepository<Player> _playerRepository;

    public TeamService(
        ITeamRepository teamRepository,
        IBaseRepository<Player> playerRepository
        )
    {
        _teamRepository = teamRepository;
        _playerRepository = playerRepository;
    }

    public void AddTeam(Team team)
    {
        _teamRepository.Create(team);
    }

    public Team GetTeam(int teamId)
    {
        var team = _teamRepository.GetById(teamId);
        return team;
    }

    public IList<Team> GetTeams()
    {
        var teams = _teamRepository.GetAll().ToList();
        return teams;
    }

    public void RemoveTeam(Team team)
    {
        _teamRepository.Delete(team);
    }
}
