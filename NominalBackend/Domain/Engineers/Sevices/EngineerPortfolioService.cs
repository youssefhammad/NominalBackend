using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Domain.Engineers.Repositories;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Items.Services
{
    public interface IEngineerPortfolioService : ICrudService<EngineerPortfolio>
    {
        public Task<bool> IsAPhotoFile(string fileName);
        public Task<EngineerPortfolio> UpdateImageUrl(EngineerPortfolio image, string url);
    }
    public class EngineerPortfolioService : CrudService<EngineerPortfolio>, IEngineerPortfolioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEngineerPortfolioRepository _engineerPortfolioRepository;

        public EngineerPortfolioService(IUnitOfWork unitOfWork, ICrudRepository<EngineerPortfolio> repository, IEngineerPortfolioRepository engineerPortfolioRepository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _engineerPortfolioRepository = engineerPortfolioRepository;
        }

        public async Task<bool> IsAPhotoFile(string fileName)
        {
            return fileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase)
                || fileName.EndsWith(".pjp", StringComparison.OrdinalIgnoreCase);
        }

        public async Task<EngineerPortfolio> UpdateImageUrl(EngineerPortfolio image, string url)
        {
            var newImage = await _engineerPortfolioRepository.UpdateImageUrl(image.id, url);
            await _unitOfWork.SaveChangesAsync(newImage);

            return image;
        }

       
    }
}