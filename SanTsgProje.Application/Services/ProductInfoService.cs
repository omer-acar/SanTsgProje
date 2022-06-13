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
        private readonly IApiService _appService;
        public ProductInfoService(IApiService appService)
        {
            _appService = appService;
        }

        public async Task<ProductInfo> GetProductInfo(string HotelId, string OfferId)
        {
            ProductInfo productInfo = null;

            //Request Json Body
            ProductInfoRequest productInfoRequest = new ProductInfoRequest() { Product = HotelId };

            //Api Url for post
            var addurl = "api/productservice/getproductInfo";

            // Post to Api and Get Response
            var response = await _appService.Post(productInfoRequest, addurl);

            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                ProductInfoResponse.Root deserializedJson = JsonConvert.DeserializeObject<ProductInfoResponse.Root>(id);

                productInfo = new ProductInfo
                {
                    HotelName = deserializedJson.body.hotel.name,
                    HotelPic = deserializedJson.body.hotel.thumbnailFull,
                    HotelPhone = deserializedJson.body.hotel.phoneNumber,
                    HotelWeb = deserializedJson.body.hotel.homePage,
                    HotelRate = deserializedJson.body.hotel.stars,
                    Description = deserializedJson.body.hotel.description.text,
                    OfferId = OfferId
                };



                foreach (var item in deserializedJson.body.hotel.seasons[0].facilityCategories[0].facilities)
                {
                    productInfo.HotelFacility.Add(item.name);
                }
             

            }
            return productInfo;
        
        }
    }
}
