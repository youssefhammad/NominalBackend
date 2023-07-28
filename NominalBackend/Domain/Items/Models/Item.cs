using NominalBackend.Domain.Categories.Models;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Purchases.Models;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Domain.Wishlists.Models;
using NominalBackend.Helpers.Enums;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Items.Models
{
    public class Item
    {
        public Item()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("state")]
        public State State { set; get; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("price_before_discount")]
        public decimal PriceBeforeDiscount { get; set;}

        [JsonPropertyName("material")]
        public string? Material { get; set; }

        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }

        [JsonPropertyName("sub_category_id")]
        public int? SubCategoryId { get; set; } // mark as nullable
        public SubCategory SubCategory { get; set; }

        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [JsonPropertyName("dimension_id")]
        public int DimensionsId { get; set; }
        public Dimensions Dimensions { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }

    }
}
