using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Models;
using NominalBackend.Generics;
using NominalBackend.Helpers.Enums;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Repositories
{
    public interface IStaticImageRepository : ICrudRepository<StaticImage>
    {
        Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId);
        Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type);
        Task<IEnumerable<StaticImage>> GetMultipleStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId);
    }

    public class StaticImageRepository : CrudRepository<StaticImage>, IStaticImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StaticImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<StaticImage>> GetMultipleStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId)
        {
            var staticImages = await _dbContext.StaticImages.
                Where(a => a.Type == type && a.ReferenceId == refrenceId).
                ToListAsync();
            return staticImages;
        }

        public async Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type, int refrenceId)
        {
            var staticImage = await _dbContext.StaticImages.
                Where(a=> a.Type == type && a.ReferenceId == refrenceId).
                FirstOrDefaultAsync();
            return staticImage;
        }

        public async Task<StaticImage> GetStaticImageforTypeByRefrenceId(StaticImageType type)
        {
            var staticImage = await _dbContext.StaticImages.
                Where(a => a.Type == type).
                FirstOrDefaultAsync();
            return staticImage;
        }
    }
}
