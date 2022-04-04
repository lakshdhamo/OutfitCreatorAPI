using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output.Outfit
{
    public record Description
    {
        [JsonProperty("language")]
        public string Language { get; init; } = default!;

        [JsonProperty("description")]
        public string Text { get; init; } = default!;

    }
}
