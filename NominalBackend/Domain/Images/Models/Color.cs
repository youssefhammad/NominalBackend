using System.Text.Json.Serialization;

namespace NominalBackend.Domain.Images.Models
{
    public class Color
    {

        public int id { get; set; }

        [JsonPropertyName("color_name")]
        public string Name { get; set; }

        [JsonPropertyName("hex_decimal")]
        public string HexDicemal { get; set; }

        public ICollection<Color>? Colors { get; set; }
    }

}
