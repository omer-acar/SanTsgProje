using Newtonsoft.Json;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models;
using SanTsgProje.Application.Models.Requests;
using SanTsgProje.Application.Models.Responses;
using SanTsgProje.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SanTsgProje.Application.Services
{
    public class PriceSearchingService : IPriceSearchingService
    {
        private readonly IApiService _apiService;

        public PriceSearchingService(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<HotelInfos>> PriceSearch(string CityId)
        {
            List<HotelInfos> list = new List<HotelInfos>();

            //Request Json Body
            PriceSearchingRequest.ArrivalLocation addCityId = new PriceSearchingRequest.ArrivalLocation() { id = CityId };
            PriceSearchingRequest.Root priceSearchingRequest = new PriceSearchingRequest.Root();
            priceSearchingRequest.arrivalLocations.Add(addCityId);

            //Api Url for post
            var addurl = "api/productservice/pricesearch";

            // Post to Api and Get Response
            var response = await _apiService.Post(priceSearchingRequest, addurl);

            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                PriceSearchingResponse.Root deserializedJson = JsonConvert.DeserializeObject<PriceSearchingResponse.Root>(id);
                foreach (var hotel in deserializedJson.body.hotels)
                {
                    foreach (var offer in hotel.offers)
                    {
                        list.Add(new HotelInfos(hotel.name, hotel.thumbnailFull, offer.price.amount, hotel.address, offer.offerId, hotel.id));
                    }

                }

            }
            return list;
        }
    }
}
