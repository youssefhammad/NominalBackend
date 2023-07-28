using NominalBackend.Domain.Categories.Models;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Helpers.Enums;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.SubCategories.Models
{
    public class SubCategory
    {
        public SubCategory()
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
        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
