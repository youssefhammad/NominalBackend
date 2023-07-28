using NominalBackend.Domain.Users.Models;
using NominalBackend.Helpers.Enums;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Purchases.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        
        [JsonPropertyName("purchase_date")]
        public DateTime PurchaseDate { get; set; }

        [JsonPropertyName("total_price")]
        public decimal TotalPrice { get; set; }

        [JsonPropertyName("payment_method")]
        public string? PaymentMethod { get; set; }

        [JsonPropertyName("purchase_date")] 
        public PaymentStatus Status { get; set; }

        [JsonPropertyName("shipping_address")]
        public string ShippingAddress { get; set; }

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
