using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Images.Repositories
{
    public interface IImageRepository : ICrudRepository<Image> 
    {
        Task<IEnumerable<Image>> GetImagesByItemId(int itemId);
        Task<Image> UpdateImageUrl(int id, string url);
    }
    public class ImageRepository : CrudRepository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Image>> GetImagesByItemId(int itemId)
        {
            var images = await _dbContext.Images.Where(a=> a.ItemId == itemId).ToListAsync();
            return images;
        }

        public async Task<Image> UpdateImageUrl(int id, string url)
        {
            var image = await _dbContext.Images.FindAsync(id);
            if (image == null)
            {
                throw new Exception("Image not found");
            }

            image.Url = url;
            _dbContext.Images.Update(image);

            return image;
        }

    }
}
