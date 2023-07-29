using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Images.Repositories
{
    public interface IImageRepository : ICrudRepository<Image> 
    {

    }
    public class ImageRepository : CrudRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
