using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Domain.Engineers.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IEngineerService : ICrudService<Engineer>
    {
        
    }
    public class EngineerService : CrudService<Engineer>, IEngineerService
    {
        private readonly IEngineerRepository _engineerRepository;

        public EngineerService(IUnitOfWork unitOfWork, ICrudRepository<Engineer> repository, IEngineerRepository engineerRepository) : base(unitOfWork, repository)
        {
            _engineerRepository = engineerRepository;
        }

      
    }
}
