﻿using Newtonsoft.Json.Linq;
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
        private readonly IUnitOfWork _unitOfWork;

        public BeginTransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> BeginTransaction(string OfferId)
        {
            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/bookingservice/begintransaction";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            BeginTransactionRequest productInfoRequest = new BeginTransactionRequest();
            productInfoRequest.offerIds.Add(OfferId);

            var response = await httpClient.PostAsJsonAsync(url, productInfoRequest);
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
