using Newtonsoft.Json;
using OutfitCreator.Domain.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto
{
    public record Outfit
    {
        [JsonProperty("totalCount")]
        public int TotalCount { get; init; } = default!;

        [JsonProperty("items")]
        public List<Item> Items { get; init; } = default!;
    }
}
