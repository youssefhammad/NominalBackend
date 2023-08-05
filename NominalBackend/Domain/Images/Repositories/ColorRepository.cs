using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Images.Repositories
{
    public interface IColorRepository : ICrudRepository<Color>
    {
        Task<IEnumerable<Color>> GetColorsForItemsById(int imageId);
    }
    public class ColorRepository : CrudRepository<Color>, IColorRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Color>> GetColorsForItemsById(int itemId)
        {
            var colors = await _dbContext.Colors
                .Where(color => color.Images.Any(image => image.Item.Id == itemId))
                .Select(color => new Color
                {
                    Id = color.Id,
                    Name = color.Name,
                    HexDicemal = color.HexDicemal
                })
                .ToListAsync();
            return colors;
        }
    }
}
