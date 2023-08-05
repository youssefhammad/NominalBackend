using Microsoft.EntityFrameworkCore;
using NominalBackend.Persistence;
using System.Xml.Linq;

namespace NominalBackend.Generics
{
    public interface ICrudRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task AddMultipleAsync(List<T> entities);
        Task UpdateMultipleAsync(List<T> entities);
    }



    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public CrudRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddMultipleAsync(List<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var entity = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return entity;
        }

        public async Task UpdateMultipleAsync(List<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            return;
        }
    }
}
