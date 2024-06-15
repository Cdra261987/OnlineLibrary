using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Data.Context;
using OnlineLibrary.Domain.Exceptions;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Data;

public class Repository<TEnt> : IRepository<TEnt> where TEnt: class
{
    private readonly OnlineLibraryDBContext _dbContext;
    private readonly DbSet<TEnt> _dbSet;

    public Repository(OnlineLibraryDBContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _dbSet = dbContext.Set<TEnt>();
    }
    
    public List<TEnt> GetAll()
    {
        return _dbSet.AsNoTracking().ToList();
    }

    public TEnt GetById(int id)
    {
        var entity = _dbSet.Find(id);

        if (entity is null)
            throw new EntityNotFoundException($"No entity found with id '{id}'.");

        return entity;
    }

    public void Add(TEnt entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEnt entity)
    {
        _dbSet.Attach(entity);
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var entity = _dbSet.Find(id);

        if (entity == null) throw new EntityNotFoundException($"No entity found with id '{id.ToString()}'");

        if (_dbContext.Entry(entity).State == EntityState.Detached)
            _dbSet.Attach(entity);
        
        _dbSet.Remove(entity);
    }

    public int SaveChanges()
    {
        return _dbContext.SaveChanges();
    }
}