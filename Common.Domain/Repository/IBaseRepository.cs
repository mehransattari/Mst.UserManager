using Common.Domain.Bases;
using System.Linq.Expressions;

namespace Common.Domain.Repository;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    string? includeString = null,
                                    bool disableTracking = true);

    Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>>? predicate = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    List<Expression<Func<T, object>>>? includes = null,
                                    bool disableTracking = true);
    Task<T?> GetByIdAsync(long id);

    Task<T?> GetByIdTracking(long id);

    Task AddAsync(T entity);

    void Add(T entity);

    Task AddRange(ICollection<T> entities);

    void Update(T entity);

    Task DeleteAsync(T entity);

    Task<int> Save();

    Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

    bool Exists(Expression<Func<T, bool>> expression);

    T? Get(long id);
}
