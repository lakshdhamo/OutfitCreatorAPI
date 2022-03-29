using Newtonsoft.Json;
using OutfitCreator.Domain.Dto;
using OutfitCreator.Domain.Dto.Input;
using OutfitCreator.Domain.Dto.Output;
using OutfitCreator.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.Services
{
    public class OutfitService : IOutfitService
    {
        public async Task<Outfit> GetOutfitDetails(OutfitRequestDto outfitRequestDto)
        {
            Outfit outfit = new();
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://api.newyorker.de/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string query = BuildQuery(outfitRequestDto);
                //var response = await client.GetAsync("csp/products/public/query?limit=30&offset=0&filters[country]=de&filters[gender]=MALE&filters[brand]=&filters[color]=&filters[web_category]=&filters[likes]=&filters[collections]=&filters[editorials]=").ConfigureAwait(false);
                var response = await client.GetAsync("csp/products/public/query?" + query).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result is not null)
                    {
                        dynamic? dynJson = JsonConvert.DeserializeObject(result);
                        if (dynJson is not null)
                            outfit = dynJson.ToObject<Outfit>();
                    }
                }
            }
            return outfit;
        }

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
            return countries;
        }

        private string BuildQuery(OutfitRequestDto outfitRequestDto)
        {
            StringBuilder query = new StringBuilder();
            query.Append("limit=" + outfitRequestDto.Limit.ToString());
            query.Append("&offset=" + outfitRequestDto.Offset.ToString());
            query.Append("&filters[country]=" + outfitRequestDto.Country);
            query.Append("&filters[gender]=" + outfitRequestDto.Gender);

            return query.ToString();
        }

    }
}
