using Newtonsoft.Json;
using OutfitCreator.Domain.Dto.Output.Outfit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output
{
    public record Item
    {
        [JsonProperty("id")]
        public string Id { get; init; } = default!;

        [JsonProperty("maintenance_group")]
        public string Name { get; set; } = default!;

        [JsonProperty("brand")]
        public string Brand { get; init; } = default!;

        [JsonProperty("variants")]
        public List<Variant> Variants { get; init; } = default!;

        [JsonProperty("descriptions")]
        public List<Description> Descriptions { get; init; } = default!;

    }
}
