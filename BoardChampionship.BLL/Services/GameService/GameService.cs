using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Enums;
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
        var games = _gameRepository
            .GetAll()
            .Where(x => x.TeamId == team.Id)
            .ToList();
        if (games.Count >= 2) // Magic digit
        {
            return true;
        }
        if (games.Count == 3) // Magic digit
        {
            // Here must be method 'AddOneMoreGame()'
            // If i will be has time, i write it ;)
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
