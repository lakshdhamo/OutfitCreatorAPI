using Microsoft.AspNetCore.Mvc;
using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Output;
using OutfitCreator.Domain.Dto.Output.Filters;
using OutfitCreator.Domain.Interfaces;

namespace OutfitCreatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutfitController : ControllerBase
    {
        private readonly IOutfitService _outfitService;
        private readonly ILogger _logger;

        public OutfitController(IOutfitService outfitService, ILogger<Outfit> logger)
        {
            _outfitService = outfitService;
            _logger = logger;
        }

        /// <summary>
        /// Gets the Outfit data
        /// </summary>
        /// <param name="limit">Number data data to be fetched</param>
        /// <param name="offset">From the offset number</param>
        /// <param name="country">Specific country</param>
        /// <param name="gender">Gender information</param>
        /// <param name="category">Optional. Any category</param>
        /// <returns>Outfit data</returns>
        [HttpGet("OutfitDetails")]
        public async Task<ActionResult<Outfit>> GetOutfitDetails(int limit, int offset, string country, string gender, string? category = "")
        {
            if (limit < 1 || offset < 0 || String.IsNullOrWhiteSpace(country) || String.IsNullOrWhiteSpace(gender))
            {
                _logger.LogError("Invalid input parameters");
                return BadRequest("Invalid input parameters");
            }

            _logger.LogInformation("GetOutfitDetails method called");
            return await _outfitService.GetOutfitDetails(limit, offset, country, gender, category).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the list of applicable country list
        /// </summary>
        /// <returns>Country list</returns>
        [HttpGet("Countries")]
        public async Task<List<Country>> GetCountry()
        {
            _logger.LogInformation("GetCountry method called");
            return await _outfitService.GetCountry().ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the filter data
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>List of filter data</returns>
        [HttpGet("Filters")]
        public async Task<ActionResult<Filter>> GetFilters(string country)
        {
            if (String.IsNullOrWhiteSpace(country))
            {
                _logger.LogError("Invalid input parameters");
                return BadRequest("Invalid input parameters");
            }

            _logger.LogInformation("GetFilters method called");
            return await _outfitService.GetFilters(country).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the translation text information
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>Dictionary data of translation text</returns>
        [HttpGet("Products")]
        public async Task<ActionResult<Dictionary<string, string>>> GetProducts(string country)
        {
            if (String.IsNullOrWhiteSpace(country))
            {
                _logger.LogError("Invalid input parameters");
                return BadRequest("Invalid input parameters");
            }

            _logger.LogInformation("GetProducts method called");
            return await _outfitService.GetProducts(country).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the particular product information
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="country">Country code</param>
        /// <returns>Particular product information</returns>
        [HttpGet("Product/{id}")]
        public async Task<ActionResult<Item>> GetProduct(string id, string country)
        {
            if (String.IsNullOrWhiteSpace(id) || String.IsNullOrWhiteSpace(country))
            {
                _logger.LogError("Invalid input parameters");
                return BadRequest("Invalid input parameters");
            }

            _logger.LogInformation("GetProduct method called");
            return await _outfitService.GetProduct(id, country).ConfigureAwait(false);
        }

    }
}
