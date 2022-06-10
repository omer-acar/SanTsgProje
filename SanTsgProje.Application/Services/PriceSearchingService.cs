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
        private readonly IUnitOfWork _unitOfWork;


        public PriceSearchingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<HotelInfos>> PriceSearch(string CityId)
        {
            List<HotelInfos> list = new List<HotelInfos>();

            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/productservice/pricesearch";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            PriceSearchingRequest.ArrivalLocation addCityId = new PriceSearchingRequest.ArrivalLocation() { id = CityId };
            PriceSearchingRequest.Root priceSearchingRequest = new PriceSearchingRequest.Root();
            priceSearchingRequest.arrivalLocations.Add(addCityId);

            var response = await httpClient.PostAsJsonAsync(url, priceSearchingRequest);
            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                PriceSearchingResponse.Root deserializedJson = JsonConvert.DeserializeObject<PriceSearchingResponse.Root>(id);
                foreach (var item in deserializedJson.body.hotels)
                {
                    foreach (var item2 in item.offers)
                    {
                        list.Add(new HotelInfos(hotelName: item.name, hotelPic: item.thumbnailFull, hotelPrice: item2.price.amount,hotelAdress:item.address,hotelOfferId:item2.offerId,hotelId:item.id));
                    }
                    
                }
               
            }
            return list;
        }
    }
}
