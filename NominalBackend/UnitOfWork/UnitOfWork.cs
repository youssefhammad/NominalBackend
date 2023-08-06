using NominalBackend.Persistence;

namespace NominalBackend.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<T> SaveChangesAsync<T>(T entity) where T : class;
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> SaveChangesAsync<T>(T entity) where T : class
        {
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
