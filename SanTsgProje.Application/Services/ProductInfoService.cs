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
    public class ProductInfoService : IProductInfoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductInfo> GetProductInfo(string HotelId, string OfferId)
        {
            ProductInfo productInfo = new ProductInfo();
            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/productservice/getproductInfo";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ProductInfoRequest productInfoRequest = new ProductInfoRequest() { Product=HotelId };

            var response = await httpClient.PostAsJsonAsync(url, productInfoRequest);
            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                ProductInfoResponse.Root deserializedJson = JsonConvert.DeserializeObject<ProductInfoResponse.Root>(id);
                
                productInfo.HotelName = deserializedJson.body.hotel.name;
                productInfo.HotelPic = deserializedJson.body.hotel.thumbnailFull;
                productInfo.HotelPhone = deserializedJson.body.hotel.phoneNumber;
                productInfo.HotelWeb = deserializedJson.body.hotel.homePage;
                productInfo.HotelRate = deserializedJson.body.hotel.stars;
                productInfo.Description = deserializedJson.body.hotel.description.text;
                productInfo.OfferId = OfferId;





                foreach (var item in deserializedJson.body.hotel.seasons[0].facilityCategories[0].facilities)
                {
                    productInfo.HotelFacility.Add(item.name);
                }
             

            }
            return productInfo;
        
        }
    }
}
