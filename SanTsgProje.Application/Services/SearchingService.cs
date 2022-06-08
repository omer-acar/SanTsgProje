using Newtonsoft.Json.Linq;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Data;
using SanTsgProje.Domain.Authentications;
using SanTsgProje.Domain.Users;
using System;
using System.Collections.Generic;
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
         
        public async Task<List<string>> Search(string query) //Searching 
        {
            List<string> list = new List<string>();
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
            var searchRequest = new SearchRequest() { ProductType = 2, Query = query, Culture = "en-US" };
            var response = await httpClient.PostAsJsonAsync(url, searchRequest);
            //If response is success filter for city
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(id);
                //Item select to each body in items and we founded array count
                var items = json.SelectToken("body.items").Value<JArray>();
                var uzun = items.Count;
                for (int i = 0; i < uzun; i++)
                {
                    //We filtered TR and Cities
                    var country = json.SelectToken($"body.items[{i}].country.id").Value<string>();
                    var city = json.SelectToken($"body.items[{i}].city.name").Value<string>();
                    if (country == "TR")
                    {
                        if ((list.IndexOf(city)) == -1)
                        {
                            list.Add(city);
                        }
                    }
                }
            }
            return list;

        }
    }

}
