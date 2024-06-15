namespace OnlineLibrary.Repositories.Interfaces;

public interface IRepository<TEntity>
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity customer);
    void Update(TEntity customer);
    void Delete(int id);
    int SaveChanges();
}