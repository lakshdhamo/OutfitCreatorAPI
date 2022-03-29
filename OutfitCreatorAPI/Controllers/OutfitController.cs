using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Input;
using OutfitCreator.Domain.Dto.Output;
using OutfitCreator.Domain.Interfaces;

namespace OutfitCreatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitService _outfitService;
        public OutfitController(IOutfitService outfitService)
        {
            _outfitService = outfitService;
        }

        [HttpPost("GetOutfitDetails")]
        public async Task<Outfit> GetOutfitDetails([FromBody] OutfitRequestDto outfitRequestDto)
        {
            return await _outfitService.GetOutfitDetails(outfitRequestDto).ConfigureAwait(false);
        }

        //[HttpGet("GetOutfitDetails")]
        //public async Task<Outfit> GetOutfitDetails(string country, string gender, string category)
        //{
        //    return await _outfitService.GetOutfitDetails(outfitRequestDto).ConfigureAwait(false);
        //}

        [HttpGet("GetCountry")]
        public async Task<List<Country>> GetCountry()
        {
            return await _outfitService.GetCountry().ConfigureAwait(false);
        }

    }
}
