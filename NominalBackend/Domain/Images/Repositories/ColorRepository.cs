using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Images.Repositories
{
    public interface IColorRepository : ICrudRepository<Color>
    {

    }
    public class ColorRepository : CrudRepository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
