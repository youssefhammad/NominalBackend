using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Wishlists.Repositories
{
    public interface IWishlistRepository : ICrudRepository<Wishlist>
    {
        Task<List<int>> GetAllWishlistForUser(string userId);
    }
    public class WishlistRepository : CrudRepository<Wishlist>, IWishlistRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public WishlistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<int>> GetAllWishlistForUser(string userId)
        {
            var wishlistsIds = await _dbContext.Wishlists.Where(a => a.UserId == userId).
                Select(b => b.ItemId).ToListAsync();

            return wishlistsIds;
        }
    }
}
