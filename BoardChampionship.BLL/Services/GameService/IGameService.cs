using BoardChampionship.DAL.Entities;

namespace BoardChampionship.BLL.Services.GameService;

public interface IGameService
{
    void StartGame(Game game);
    Game GetGame(int id);
    IList<Game> GetGames();
    void Delete(int id);
    bool DetermineTheWinner(Team team);
}