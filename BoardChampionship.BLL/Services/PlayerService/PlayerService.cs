using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.PlayerRepository;

namespace BoardChampionship.BLL.Services.PlayerService;

public class PlayerService : IPlayerService
{
    private readonly IBaseRepository<Player> _playerRepository;

    public PlayerService(
        IBaseRepository<Player> playerRepository
        )
    {
        _playerRepository = playerRepository;
    }

    public void AddPlayer(Player player)
    {
        _playerRepository.Create(player);
    }

    public Player GetPlayer(int id)
    {
        var player = _playerRepository.GetById(id);
        if (player == null)
        {
            throw new Exception($"No Player with '{id}' ID");
        }
        return player;
    }

    public IQueryable<Player> GetPlayers()
    {
        var players = _playerRepository.GetAll();
        return players;
    }

    public void RemovePlayer(int id)
    {
        var player = _playerRepository.GetById(id);
        if (player == null)
        {
            throw new Exception($"No Player with '{id}' ID");
        }
        _playerRepository.Delete(player);
    }
}
