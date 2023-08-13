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
        Task<bool> ValidateIsDefaultItemImage(List<Image> images);
        Task<bool> ValidateIsDefaultItemColor(List<Image> images);
        Task<Image> UpdateImageUrl(Image image, string url);
    }
    public class ImageService : CrudService<Image>, IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageRepository _imageRepository;

        public ImageService(IUnitOfWork unitOfWork, ICrudRepository<Image> repository, IImageRepository imageRepository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> GetImagesByItemId(int itemId)
        {
            var images = await _imageRepository.GetImagesByItemId(itemId);
            foreach(var ima in images)
            {
                ima.Data = null;
            };
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

        public async Task<bool> ValidateIsDefaultItemImage(List<Image> images)
        {
            int count = images.Count(image => image.IsDefaultItemImage);
            return count == 1;
        }

        public async Task<bool> ValidateIsDefaultItemColor(List<Image> images)
        {
           bool isValid = images
                .GroupBy(image => image.ColorId)
                .All(group => group.Count(image => image.IsDefaultItemColor) == 1);

            return isValid;
        }

        public async Task<Image> UpdateImageUrl(Image image, string url)
        {
            var newImage = await _imageRepository.UpdateImageUrl(image.Id, url);
            await _unitOfWork.SaveChangesAsync(newImage);

            return image;
        }

        
    }
}
