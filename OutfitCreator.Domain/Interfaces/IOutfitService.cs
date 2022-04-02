using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Output;
using OutfitCreator.Domain.Dto.Output.Filters;

namespace OutfitCreator.Domain.Interfaces
{
    public interface IOutfitService
    {
        /// <summary>
        /// Gets the Outfit data
        /// </summary>
        /// <param name="limit">Number data data to be fetched</param>
        /// <param name="offset">From the offset number</param>
        /// <param name="country">Specific country</param>
        /// <param name="gender">Gender information</param>
        /// <param name="category">Optional. Any category</param>
        /// <returns>Outfit data</returns>
        Task<Outfit> GetOutfitDetails(int limit, int offset, string country, string gender, string category);

        /// <summary>
        /// Gets the list of applicable country list
        /// </summary>
        /// <returns>Country list</returns>
        Task<List<Country>> GetCountry();

        /// <summary>
        /// Gets the filter data
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>List of filter data</returns>
        Task<Filter> GetFilters(string country);

        /// <summary>
        /// Gets the translation text information
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>Dictionary data of translation text</returns>
        Task<Dictionary<string, string>> GetProducts(string country);

        /// <summary>
        /// Gets the particular product information
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="country">Country code</param>
        /// <returns>Particular product information</returns>
        Task<Item> GetProduct(string id, string country);

    }
}
