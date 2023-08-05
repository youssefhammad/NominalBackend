using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Images.Services
{
    public interface IImageService : ICrudService<Image>
    {
        public Task<bool> IsAPhotoFile(string fileName);
        Task<IEnumerable<Image>> GetImagesByItemId(int itemId);
    }
    public class ImageService : CrudService<Image>, IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IUnitOfWork unitOfWork, ICrudRepository<Image> repository, IImageRepository imageRepository) : base(unitOfWork, repository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> GetImagesByItemId(int itemId)
        {
            var images = await _imageRepository.GetImagesByItemId(itemId);
            return images;
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
