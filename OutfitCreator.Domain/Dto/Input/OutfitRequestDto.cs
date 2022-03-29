using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Dto.Input
{
    public record OutfitRequestDto
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }


    }
}
