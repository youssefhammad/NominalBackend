using System.Text.Json.Serialization;

namespace NominalBackend.Helpers.Filters
{
    public class ItemFilter
    {
        [JsonPropertyName("price_from")]
        public decimal? PriceFrom { get; set; }

        [JsonPropertyName("price_to")]
        public decimal? PriceTo { get; set; }

        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("sub_category_id")]
        public int? SubCategoryId { get; set; }

    }
}
