using Newtonsoft.Json;
using OutfitCreator.Domain.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Output.Filters
{
    public record Gender
    {
        [JsonProperty("categories")]
        public List<Category> Categories { get; init; } = default!;
    }
}
