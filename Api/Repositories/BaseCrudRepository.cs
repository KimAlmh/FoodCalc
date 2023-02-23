using System.Linq.Expressions;
using Api.Data;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories;

public abstract class BaseCrudRepository<T> : IBaseCrudRepository<T> where T : class
{
    protected FoodCalcContext RepositoryContext { get; set; } 
    
    public BaseCrudRepository(FoodCalcContext repositoryContext) 
    {
        RepositoryContext = repositoryContext; 
    }

    public IQueryable<T> GetAll() => RepositoryContext.Set<T>().AsNoTracking();

    public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression) =>
        RepositoryContext.Set<T>().Where(expression).AsNoTracking();

    public async Task<bool> SaveAll() => await RepositoryContext.SaveChangesAsync() > 0;

    public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

    public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);

    public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
}