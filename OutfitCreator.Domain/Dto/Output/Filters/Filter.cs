using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output.Filters
{
    public record Filter
    {
        [JsonProperty("men")]
        public Gender Men { get; init; } = default!;

        [JsonProperty("none")]
        public Gender None { get; init; } = default!;

        [JsonProperty("women")]
        public Gender Women { get; init; } = default!;
    }
}
