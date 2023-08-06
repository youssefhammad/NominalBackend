using NominalBackend.UnitOfWork;

namespace NominalBackend.Generics
{
    public interface ICrudService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<List<T>> AddMultipleAsync(List<T> entities);
        Task<List<T>> UpdateMultipleAsync(List<T> entities);
    }
    public class CrudService<T> : ICrudService<T> where T: class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICrudRepository<T> _repository;

        public CrudService(IUnitOfWork unitOfWork, ICrudRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return await _unitOfWork.SaveChangesAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            return await _unitOfWork.SaveChangesAsync(entity);
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            return await _unitOfWork.SaveChangesAsync(entity);
        }

        public async Task<List<T>> AddMultipleAsync(List<T> entities)
        {
            await _repository.AddMultipleAsync(entities);
            return await _unitOfWork.SaveChangesAsync(entities);
        }

        public async Task<List<T>> UpdateMultipleAsync(List<T> entities)
        {
            await _repository.UpdateMultipleAsync(entities);
            return await _unitOfWork.SaveChangesAsync(entities);
        }
    }
}
