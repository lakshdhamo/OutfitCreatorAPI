using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output
{
    public record Country
    {
        [JsonProperty("iso_3166")]
        public string Code { get; init; }

        [JsonProperty("name")]
        public string Name { get; init; }
    }
}
