using Microsoft.AspNetCore.Identity;
using NominalBackend.Domain.Purchases.Models;
using NominalBackend.Domain.Wishlists.Models;

namespace NominalBackend.Domain.ApplicationUser.Models
{
    public class ApplicationUser : IdentityUser
    {


        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
    }
}
