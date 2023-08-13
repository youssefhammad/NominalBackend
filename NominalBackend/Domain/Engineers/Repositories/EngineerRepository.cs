using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Engineers.Repositories
{
    public interface IEngineerRepository : ICrudRepository<Engineer>
    {

    }
    public class EngineerRepository : CrudRepository<Engineer> ,IEngineerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EngineerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
