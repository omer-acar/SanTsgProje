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
        private readonly IUnitOfWork _unitOfWork;

        public CommitTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CompleteReservation(string TransactionId)
        {
            
            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/bookingservice/committransaction";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            CommitTransactionRequest commitTransactionRequest = new CommitTransactionRequest() { TransactionId=TransactionId};
            var response = await httpClient.PostAsJsonAsync(url, commitTransactionRequest);
            //If response is success , Select reservation number in Json Object
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
