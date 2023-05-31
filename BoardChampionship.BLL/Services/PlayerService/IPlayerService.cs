using BoardChampionship.DAL.Entities;

namespace BoardChampionship.BLL.Services.PlayerService
{
    public interface IPlayerService
    {
        bool AddPlayer(Player player);
        Player GetPlayer(int id);
        IQueryable<Player> GetPlayers();
        void RemovePlayer(int id);
    }
}