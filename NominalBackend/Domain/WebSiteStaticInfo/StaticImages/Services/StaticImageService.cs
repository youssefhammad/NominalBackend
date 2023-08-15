using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Models;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Repositories;
using NominalBackend.Generics;
using NominalBackend.Helpers.Enums;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Services
{
    public interface IStaticImageService : ICrudService<StaticImage>
    {
        Task<bool> IsAPhotoFile(string fileName);
        Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId);
        Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type);
        Task<IEnumerable<StaticImage>> GetMultipleStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId);
    }

    public class StaticImageService : CrudService<StaticImage>, IStaticImageService
    {
        private readonly IStaticImageRepository _staticImageRepository;

        public StaticImageService(IUnitOfWork unitOfWork, ICrudRepository<StaticImage> repository,
            IStaticImageRepository staticImageRepository) : base(unitOfWork, repository)
        {
            _staticImageRepository = staticImageRepository;
        }

        public async Task<IEnumerable<StaticImage>> GetMultipleStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId)
        {
            var staticImages = await _staticImageRepository.GetMultipleStaticImageforTypeByRefrenceId(type, refrenceId);
            return staticImages;
        }

        public async Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId)
        {
            var staticImage = await _staticImageRepository.GetStaticImageforTypeByRefrenceId(type, refrenceId);
            return staticImage;
        }

        public async Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type)
        {
            var CoverPhotoImage = await _staticImageRepository.GetStaticImageforTypeByRefrenceId(type);
            return CoverPhotoImage;
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
