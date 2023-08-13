using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Engineers.Models
{
    public class Engineer
    {
        public int id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("description")]
        public string? description { get; set; }
        [JsonPropertyName("speciality")]
        public string? speciality { get; set; }


        public ICollection<EngineerPortfolio>? PortfolioImages { get; set; }

    }
}
