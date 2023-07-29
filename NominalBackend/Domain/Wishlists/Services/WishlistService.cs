using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Generics;
using NominalBackend.UnitOfWork;

namespace NominalBackend.Domain.Wishlists.Services
{
    public interface IWishlistService : ICrudService<Wishlist>
    {

    }
    public class WishlistService : CrudService<Wishlist>, IWishlistService
    {
        public WishlistService(IUnitOfWork unitOfWork, ICrudRepository<Wishlist> repository) : base(unitOfWork, repository)
        {
        }
    }
}
