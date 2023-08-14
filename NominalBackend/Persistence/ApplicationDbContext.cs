using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Categories.Models;
using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Purchases.Models;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Domain.Users.Models;
using NominalBackend.Domain.Wishlists.Models;

namespace NominalBackend.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            modelBuilder.Entity<Purchase>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId)
            .IsRequired();

            modelBuilder.Entity<Wishlist>()
            .HasOne(p => p.User)
            .WithMany(u => u.Wishlists)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData
                (
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "Client", ConcurrencyStamp = "2", NormalizedName = "Client" }

                );
        }

        //public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Dimensions> Dimensions { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<EngineerPortfolio> EngineerPortfolios { get; set; }
    }
}
