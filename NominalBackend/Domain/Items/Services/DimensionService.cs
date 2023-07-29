using NominalBackend.Domain.Items.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IDimensionService : ICrudService<Dimensions>
    {

    }
    public class DimensionService : CrudService<Dimensions>, IDimensionService
    {
        public DimensionService(IUnitOfWork unitOfWork, ICrudRepository<Dimensions> repository) : base(unitOfWork, repository)
        {
        }
    }
}
