using Newtonsoft.Json.Linq;
using SanTsgProje.Application.Interfaces;
using SanTsgProje.Application.Models.Requests;
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
    public class BeginTransactionService : IBeginTransactionService
    {
        private readonly IApiService _apiService;

        public BeginTransactionService(IApiService apiService)
        {

            _apiService = apiService;
        }

        public async Task<string> BeginTransaction(string OfferId)
        {
            //Request Json Body
            BeginTransactionRequest productInfoRequest = new BeginTransactionRequest();
            productInfoRequest.offerIds.Add(OfferId);

            //Api Url for post
            var addurl = "api/bookingservice/begintransaction";

            // Post to Api and Get Response
            var response = await _apiService.Post(productInfoRequest, addurl);

            //If response is success , Select transaction id in json object.
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(id);
                var transactionId = json.SelectToken("body.transactionId").Value<string>();
                return transactionId;

            }

            return null;
        }
    
    }
}
