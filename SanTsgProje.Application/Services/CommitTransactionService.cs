using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class CommitTransactionService : ICommitTransactionService
    {

        private readonly IApiService _apiService;

        public CommitTransactionService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<string> CompleteReservation(string TransactionId)
        {
            //Request Json Body
            CommitTransactionRequest commitTransactionRequest = new CommitTransactionRequest() { TransactionId = TransactionId };

            //Api Url for post
            var addurl = "api/bookingservice/committransaction";

            // Post to Api and Get Response
            var response = await _apiService.Post(commitTransactionRequest,addurl);


            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(id);
                var reservationNumber = json.SelectToken("body.reservationNumber").Value<string>();
                return reservationNumber;
            }
            return null;

        }
    }
}
