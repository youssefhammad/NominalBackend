using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Generics;
using NominalBackend.Persistence;

namespace NominalBackend.Domain.Wishlists.Repositories
{
    public interface IWishlistRepository : ICrudRepository<Wishlist>
    {

    }
    public class WishlistRepository : CrudRepository<Wishlist>, IWishlistRepository
    {
        public WishlistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
