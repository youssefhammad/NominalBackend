using NominalBackend.Helpers.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Models
{
    public class StaticImage
    {
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public StaticImageType Type { get; set; }

        [JsonPropertyName("bytes")]
        public byte[] Data { get; set; }

        [JsonPropertyName("reference_id ")]
        public int? ReferenceId { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("url")]
        public string? URL { get; set; }

        [JsonPropertyName("image_name")]
        public string? ImageName { get; set;}
    
    }
}
