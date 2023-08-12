using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Users.Models;
using NominalBackend.Helpers.Enums;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Wishlists.Models
{
    public class Wishlist
    {
        public Wishlist()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("state")]
        public State State { set; get; }

        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        public ApplicationUser.Models.ApplicationUser User { get; set; }
    }
}
