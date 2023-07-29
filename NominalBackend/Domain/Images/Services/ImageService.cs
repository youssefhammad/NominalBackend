using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Images.Services
{
    public interface IImageService : ICrudService<Image>
    {
        public Task<bool> IsAPhotoFile(string fileName);
    }
    public class ImageService : CrudService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, ICrudRepository<Image> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<bool> IsAPhotoFile(string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".pjp", StringComparison.OrdinalIgnoreCase);
        }
    }
}
