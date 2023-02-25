using System.Linq.Expressions;

namespace Api.Interfaces;

public interface IBaseCrudRepository<T>
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> expression);
    Task<T?> GetByCondition(Expression<Func<T, bool>> expression);
    Task<bool> SaveAll();
    Task<bool> CheckIfExists(Expression<Func<T, bool>> expression);
    Task Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}