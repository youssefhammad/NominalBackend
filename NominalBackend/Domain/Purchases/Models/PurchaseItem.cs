using NominalBackend.Domain.Items.Models;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Purchases.Models
{
    public class PurchaseItem
    {
        public int Id { get; set; }

        [JsonPropertyName("purchase_id")]
        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        
        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
