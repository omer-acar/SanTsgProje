using Newtonsoft.Json;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Application.Models.Requests;
using SanTsgProje.Application.Models.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class SearchingService : ISearchingService
    {
        private readonly IApiService _apiService;

        public SearchingService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<CityInfos>> SearchCities(string query) //Searching Cities 
        {
            List<CityInfos> list2 = new List<CityInfos>();

            //Request Json Body
            var searchRequest = new SearchRequest() { Query = query, Culture = "en-US" };

            //Api Url for post
            var addurl = "api/productservice/getarrivalautocomplete";

            // Post to Api and Get Response
            var response = await _apiService.Post(searchRequest, addurl);

            //If response is success filter for city
            if (response.IsSuccessStatusCode)
            {
                var read = await response.Content.ReadAsStringAsync();
                SearchingResponse.Root deserializedProduct = JsonConvert.DeserializeObject<SearchingResponse.Root>(read);

                //Item select to each body in items
                foreach (var item in deserializedProduct.body.items)
                {
                    if (item.country.id == "TR" && item.type == 1)
                    {
                        list2.Add(new CityInfos(name: item.city.name, id: item.city.id, country: item.country.id));
                    }
                }

            }
            return list2;

        }
    }

}
