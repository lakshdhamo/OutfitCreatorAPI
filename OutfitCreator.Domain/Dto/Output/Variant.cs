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
        public string Id { get; init; }

        [JsonProperty("product_id")]
        public string ProductId { get; init; }

        [JsonProperty("currency")]
        public string Currency { get; init; }

        [JsonProperty("original_price")]
        public decimal OriginalPrice { get; set; }

        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }

        [JsonProperty("sizes")]
        public List<Size> Sizes { get; init; }

        [JsonProperty("images")]
        public List<Image> Images { get; init; }

    }
}
