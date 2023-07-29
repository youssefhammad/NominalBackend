using NominalBackend.Domain.Items.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Items.Repositories
{
    public interface IDimensionRepository : ICrudRepository<Dimensions>
    {

    }
    public class DimensionRepository : CrudRepository<Dimensions>, IDimensionRepository
    {
        public DimensionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
