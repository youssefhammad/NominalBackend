using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Generics;
using NominalBackend.Helpers.Enums;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Wishlists.Repositories
{
    public interface IWishlistRepository : ICrudRepository<Wishlist>
    {
        Task<List<int>> GetAllWishlistForUser(string userId);
        Task<Wishlist> GetWishlistByItemId(int itemId);
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
            var wishlistsIds = await _dbContext.Wishlists
                                                .Where(a => a.UserId == userId && a.State == State.Active)
                                                .Select(b => b.ItemId)
                                                .ToListAsync();

            return wishlistsIds;
        }

        public async Task<Wishlist> GetWishlistByItemId(int itemId)
        {
            var wishlist = await _dbContext.Wishlists.Where(a => a.ItemId == itemId).FirstOrDefaultAsync();
            return wishlist;
        }
    }
}
