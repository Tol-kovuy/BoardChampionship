using BoardChampionship.DAL.Entities;
using BoardChampionship.DAL.Repositories.WinnerRepostory;

namespace BoardChampionship.BLL.Services.WinnerService;

public class WinnerService : IWinnerService
{
    private readonly WinnerRepository _winnerRepository;

    public WinnerService(
        WinnerRepository winnerRepository
        )
    {
        _winnerRepository = winnerRepository;
    }

    public void Add(Winner winner)
    {
        _winnerRepository.Create(winner);
    }

    public Winner Get(int id)
    {
        var winner = _winnerRepository.GetById(id);
        return winner;
    }

    public IList<Winner> GetAll()
    {
        var winners = _winnerRepository.GetAll().ToList();
        return winners;
    }
}
