using System.Linq.Expressions;

namespace Ecommerce.API.Repository.Interfaces
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            int pageNumber,
            int pageSize,
            bool ascending = true,
            Expression<Func<T, object>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            bool tracking = true,
            params Expression<Func<T, object>>[] includes
            );

        Task<T> GetAsync(
            Expression<Func<T, bool>> filter,
            bool tracking = true,
            params Expression<Func<T, object>>[] includes
            );
        Task<T?> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        Task Update(T entity);

        void Delete(T entity);

        Task DeleteById(Guid id);

        void DeleteRange(IEnumerable<T> entities);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

        Task<int> SaveChangesAsync();
    }
}
