using System.Linq.Expressions;

namespace Contracts;

public interface IRepositoryBase<T>
{
    void Create(T entity);

    IQueryable<T> FindAll(bool trackChanges);

    IQueryable<T> FindByCondintion(Expression<Func<T, bool>> expression, bool trackChanges);

    void Update(T entity);

    void Delete(T entity);
}