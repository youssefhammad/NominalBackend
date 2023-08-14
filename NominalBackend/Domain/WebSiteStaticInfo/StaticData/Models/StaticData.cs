using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NominalBackend.Domain.WebSiteStaticInfo.StaticData.Models
{
    public class StaticData
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Key is required")]
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
