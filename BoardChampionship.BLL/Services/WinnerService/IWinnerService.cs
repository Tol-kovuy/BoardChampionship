using BoardChampionship.DAL.Entities;

namespace BoardChampionship.BLL.Services.WinnerService
{
    public interface IWinnerService
    {
        void Add(Winner winner);
        Winner Get(int id);
        IList<Winner> GetAll();
    }
}