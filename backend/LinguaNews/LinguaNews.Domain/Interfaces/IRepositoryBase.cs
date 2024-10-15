using System.Linq.Expressions;

namespace LinguaNews.Domain.Interfaces;

public interface IRepositoryBase<T> where T : class
{
    Task<IReadOnlyList<T>> QueryListAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        List<Expression<Func<T, object>>>? includes = null,
        bool disableTracking = true);

    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}