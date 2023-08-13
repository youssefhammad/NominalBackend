using NominalBackend.Domain.Items.Models;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Engineers.Models
{
    public class EngineerPortfolio
    {
        public int id { get; set; }
        [JsonPropertyName("filename")]
        public string ImageName { get; set; }

        [JsonPropertyName("bytes")]
        public byte[] Data { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }


        [JsonPropertyName("engineer_id")]
        public int EngineerId { get; set; }
        public Engineer? engineer { get; set; }
    }
}
