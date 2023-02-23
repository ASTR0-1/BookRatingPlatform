using System.Linq.Expressions;

namespace BookRatingPlatform.DAL.Interfaces;

internal interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T> GetAsync(int id);

    IQueryable<T> Find(Func<T, bool> predicate);

    Task<T> AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T id);
}
