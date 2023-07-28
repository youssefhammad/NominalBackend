using NominalBackend.UnitOfWork;

namespace NominalBackend.Generics
{
    public interface ICrudService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
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

        public async Task<int> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
