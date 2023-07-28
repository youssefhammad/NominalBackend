using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Categories.Models;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Purchases.Models;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Domain.Users.Models;
using NominalBackend.Domain.Wishlists.Models;

namespace NominalBackend.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }
    }
}
