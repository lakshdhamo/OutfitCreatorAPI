using Newtonsoft.Json;
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
        public string Id { get; init; }

        [JsonProperty("maintenance_group")]
        public string Name { get; init; }

        [JsonProperty("variants")]
        public List<Variant> Variants { get; init; }

    }
}
