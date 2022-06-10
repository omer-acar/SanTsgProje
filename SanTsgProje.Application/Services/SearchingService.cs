using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Application.Models.Requests;
using SanTsgProje.Application.Models.Responses;
using SanTsgProje.Data;
using SanTsgProje.Domain.Authentications;
using SanTsgProje.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class SearchingService : ISearchingService
    {
        private readonly IUnitOfWork _unitOfWork;


        public SearchingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CityInfos>> SearchCities(string query) //Searching Cities 
        {
            List<CityInfos> list2 = new List<CityInfos>();

            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/productservice/getarrivalautocomplete";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var searchRequest = new SearchRequest() { Query = query, Culture = "en-US" };
            var response = await httpClient.PostAsJsonAsync(url, searchRequest);

            //If response is success filter for city
            if (response.IsSuccessStatusCode)
            {
                var read = await response.Content.ReadAsStringAsync();
                SearchingResponse.Root deserializedProduct = JsonConvert.DeserializeObject<SearchingResponse.Root>(read);

                //Item select to each body in items
                foreach (var item in deserializedProduct.body.items)
                {   if (item.country.id == "TR" && item.type==1)
                    {
                            list2.Add(new CityInfos(name: item.city.name, id: item.city.id, country: item.country.id));
                    }
                }
                
            }
            return list2;

        }
    }

}
