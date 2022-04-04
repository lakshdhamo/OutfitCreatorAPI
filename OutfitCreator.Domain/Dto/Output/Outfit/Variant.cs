using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output
{
    public record Variant
    {
        [JsonProperty("id")]
        public string Id { get; init; } = default!;

        [JsonProperty("product_id")]
        public string ProductId { get; init; } = default!;

        [JsonProperty("currency")]
        public string Currency { get; init; } = default!;

        [JsonProperty("color_group")]
        public string Color { get; init; } = default!;

        [JsonProperty("original_price")] 
        public decimal OriginalPrice { get; set; } = default!;

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; } = default!;

        [JsonProperty("sizes")]
        public List<Size> Sizes { get; init; } = default!;

        [JsonProperty("images")]
        public List<Image> Images { get; init; } = default!;

    }
}
