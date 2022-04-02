using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output.Filters
{
    public class Filter
    {
        [JsonProperty("men")]
        public Gender Men { get; set; }

        [JsonProperty("none")]
        public Gender None { get; set; }

        [JsonProperty("women")]
        public Gender Women { get; set; }
    }
}
