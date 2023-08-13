using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Engineers.Repositories
{
    public interface IEngineerPortfolioRepository : ICrudRepository<EngineerPortfolio>
    {
        Task<EngineerPortfolio> UpdateImageUrl(int id, string url);
    }
    public class EngineerPortfolioRepository : CrudRepository<EngineerPortfolio>, IEngineerPortfolioRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EngineerPortfolioRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EngineerPortfolio> UpdateImageUrl(int id, string url)
        {
            var image = await _dbContext.EngineerPortfolios.FindAsync(id);
            if (image == null)
            {
                throw new Exception("Image not found");
            }

            image.Url = url;
            _dbContext.EngineerPortfolios.Update(image);

            return image;
        }

        

    }
}