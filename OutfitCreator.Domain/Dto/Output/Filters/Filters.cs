using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output.Filters
{
    public record Filters
    {
        [JsonProperty("name")]
        public string Name { get; init; } = default!;

        [JsonProperty("value")]
        public string Value { get; init; } = default!;
    }
}
