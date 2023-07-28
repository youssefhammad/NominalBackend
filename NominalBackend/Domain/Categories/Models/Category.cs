using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Helpers.Enums;
using System.Text.Json.Serialization;
using static NominalBackend.Helpers.Enums.Enumerators;

namespace NominalBackend.Domain.Categories.Models
{
    public class Category
    {
        public Category()
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
        public ICollection<SubCategory>? SubCategories { get; set; }
        public ICollection<Item>? Items { get; set; }

    }
}
