using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Input;
using OutfitCreator.Domain.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Interfaces
{
    public interface IOutfitService
    {
        Task<Outfit> GetOutfitDetails(OutfitRequestDto outfitRequestDto);

        Task<List<Country>> GetCountry();

    }
}
