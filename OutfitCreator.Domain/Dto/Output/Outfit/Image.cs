using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output
{
    public record Image
    {
        [JsonProperty("key")]
        public string Key { get; init; } = default!;

        [JsonProperty("type")]
        public string Type { get; init; } = default!;

    }
}
