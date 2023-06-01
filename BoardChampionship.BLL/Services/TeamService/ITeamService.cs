using BoardChampionship.DAL.Entities;

namespace BoardChampionship.BLL.Services.TeamService
{
    public interface ITeamService
    {
        void AddTeam(Team team);
        Team GetTeam(int teamId);
        IList<Team> GetTeams();
        void RemoveTeam(Team team);
    }
}