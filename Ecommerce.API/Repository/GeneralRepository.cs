using Ecommerce.API.Data;
using Ecommerce.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.API.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GeneralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        public async Task<IEnumerable<T>> GetAllAsync
            (
            int pageNumber,
            int pageSize,
            bool ascending = true,
            Expression<Func<T, object>> orderBy = null,
            Expression<Func<T, bool>> filter = null,
            bool tracking = true,
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> query = _context.Set<T>();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);
            }

            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> filter,
            bool tracking = true,
            params Expression<Func<T, object>>[] includes
            )
        {
            IQueryable<T> query = _context.Set<T>();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task AddAsync(T entity) => await _context.Set<T>().AddAsync(entity);
        public async Task Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public async Task DeleteById(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }

        }

        public void DeleteRange(IEnumerable<T> entities) => _context.Set<T>().RemoveRange(entities);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => await _context.Set<T>().AnyAsync(predicate);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
