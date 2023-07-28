using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Items.Models
{
    public class Dimensions
    {
        public int Id { get; set; }

        [JsonPropertyName("width")]
        public decimal? Width { get; set; }

        [JsonPropertyName("height")]
        public decimal? Height { get; set; }
        
        [JsonPropertyName("depth")]
        public decimal Depth { get; set; }

        [JsonPropertyName("unit")]
        public string? Unit { get; set; }
    }
}
