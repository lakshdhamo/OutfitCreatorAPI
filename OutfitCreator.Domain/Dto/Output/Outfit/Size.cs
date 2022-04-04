using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output
{
    public record Size
    {
        [JsonProperty("size_value")]
        public string SizeValue { get; init; } = default!;

        [JsonProperty("size_name")]
        public string SizeName { get; init; } = default!;


    }
}
