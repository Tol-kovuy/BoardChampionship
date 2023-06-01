namespace BoardChampionship.DAL.Repositories.PlayerRepository;

public interface IBaseRepository<T>
{
    void Create(T entity);
    T GetById(int id);
    IQueryable<T> GetAll();
    void Update(T entity);
    void Delete(T entity);
}