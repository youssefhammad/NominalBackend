using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Images.Services
{
    public interface IImageService : ICrudService<Image>
    {

    }
    public class ImageService : CrudService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, ICrudRepository<Image> repository) : base(unitOfWork, repository)
        {
        }
    }
}
