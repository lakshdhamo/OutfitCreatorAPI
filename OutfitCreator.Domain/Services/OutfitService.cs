using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Output;
using OutfitCreator.Domain.Dto.Output.Filters;
using OutfitCreator.Domain.Dto.Output.Outfit;
using OutfitCreator.Domain.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace OutfitCreator.Domain.Services
{
    public class OutfitService : IOutfitService
    {
        private readonly ILogger _logger;

        public OutfitService(ILogger logger)
        {
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
        public async Task<Outfit> GetOutfitDetails(int limit, int offset, string country, string gender, string category)
        {
            Outfit outfit = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string query = BuildOutfitQuery(limit, offset, country, gender, category);
                var response = await client.GetAsync("csp/products/public/query?" + query).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                        {
                            outfit = dynJson.ToObject<Outfit>();
                            foreach (var item in outfit.items)
                            {
                                Description? description = item.Descriptions.FirstOrDefault(x => x.Language == country);
                                if (description == null)
                                {
                                    description = item.Descriptions.Single(x => x.Language == "EN");
                                }
                                item.Name = description.Text;
                            }
                        }

                    }
                }
            }
            _logger.LogInformation("Fetched outfit details");
            return outfit;
        }

        /// <summary>
        /// Gets the list of applicable country list
        /// </summary>
        /// <returns>Country list</returns>
        public async Task<List<Country>> GetCountry()
        {
            List<Country> countries = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("public/countries").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                            countries = dynJson.ToObject<List<Country>>();
                    }
                }
            }
            _logger.LogInformation("Fetched Country list");
            return countries;
        }

        /// <summary>
        /// Gets the filter data
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>List of filter data</returns>
        public async Task<Filter> GetFilters(string country)
        {
            Filter filter = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("csp/products/public/filters?country=" + country.ToLowerInvariant()).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                            filter = dynJson.ToObject<Filter>();
                    }
                }
            }
            _logger.LogInformation("Fetched filter data");
            return filter;
        }

        /// <summary>
        /// Gets the translation text information
        /// </summary>
        /// <param name="country">Country code</param>
        /// <returns>Dictionary data of translation text</returns>
        public async Task<Dictionary<string, string>> GetProducts(string country)
        {
            Dictionary<string, string> products = new Dictionary<string, string>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("translations/country/" + country.ToLowerInvariant() + "/products").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                            products = dynJson.ToObject<Dictionary<string, string>>();
                    }
                }
            }
            _logger.LogInformation("Fetched translation texts");
            return products;
        }

        /// <summary>
        /// Gets the particular product information
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <param name="country">Country code</param>
        /// <returns>Particular product information</returns>
        public async Task<Item> GetProduct(string id, string country)
        {
            Item item = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("csp/products/public/product/" + id + "?country=" + country.ToLowerInvariant()).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                        {
                            item = dynJson.ToObject<Item>();
                            Description? description = item.Descriptions.FirstOrDefault(x => x.Language == country);
                            if (description == null)
                            {
                                description = item.Descriptions.Single(x => x.Language == "EN");
                            }
                            item.Name = description.Text;
                        }
                    }
                }
            }
            _logger.LogInformation("Fetched particular product data");
            return item;
        }

        /// <summary>
        /// Prepare query parameter
        /// </summary>
        /// <param name="limit">Number data data to be fetched</param>
        /// <param name="offset">From the offset number</param>
        /// <param name="country">Specific country</param>
        /// <param name="gender">Gender information</param>
        /// <param name="category">Optional. Any category</param>
        /// <returns></returns>
        private static string BuildOutfitQuery(int limit, int offset, string country, string gender, string category)
        {
            StringBuilder query = new StringBuilder();
            query.Append("limit=" + limit.ToString());
            query.Append("&offset=" + offset.ToString());
            query.Append("&filters[country]=" + country);
            query.Append("&filters[gender]=" + gender);
            query.Append("&filters[web_category]=" + category);

            return query.ToString();
        }

    }
}
