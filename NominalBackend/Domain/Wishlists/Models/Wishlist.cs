﻿using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Users.Models;
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

        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
