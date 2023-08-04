using NominalBackend.Domain.Items.Models;
using NominalBackend.Helpers.Enums;
using System.IO;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Images.Models
{
    public class Image
    {
        public Image()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        public int Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("filename")]
        public string ImageName { get; set; }

        [JsonPropertyName("bytes")]
        public byte[] Data { get; set; }

        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("is_default_item_image")]
        public bool IsDefaultItemImage { get; set; }  //default image to show in home page

        [JsonPropertyName("is_default_item_color")]
        public bool IsDefaultItemColor { get; set; } //default image to show per every color in same item

        [JsonPropertyName("state")]
        public State State { get; set; }

        

        [JsonPropertyName("item_id")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int ColorId { get; set; }
        public Color Color{ get; set; }
    }
}
