using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.GameRepository;

namespace BoardChampionship.BLL.Services.GameService;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;

    public GameService(
        IGameRepository gameRepository
        )
    {
        _gameRepository = gameRepository;
    }

    public void Delete(int id)
    {
        var game = _gameRepository.GetById(id);
        _gameRepository.Delete(game);
    }

    public bool DetermineTheWinner(Team team)
    {
        var games = _gameRepository.GetAll().Where(team => team.TeamId == team.Id);

        var res = games.Select(result => result.GameResult == DAL.Enums.GameResultType.Win)
            .ToList();
        if (res.Count > 2)
        {
            return true;
        }
        return false;
    }

    public Game GetGame(int id)
    {
        var game = _gameRepository.GetById(id);
        return game;
    }

    public IList<Game> GetGames()
    {
        var games = _gameRepository.GetAll().ToList();
        return games;
    }

    public void StartGame(Game game)
    {
        _gameRepository.Create(game);
    }
}
