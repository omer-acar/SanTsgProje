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
    public class SetReservationService : ISetReservationService
    {
        private readonly IApiService _apiService;

        public SetReservationService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<Reservation> SetReservation(string FistName, string LastName, string Email, string transactionId)
        {
            Reservation reservation = null;
            
            //Request Json Body
            #region SetReservation Request
            SetReservationRequest.Rootobject reservationRequest = new SetReservationRequest.Rootobject()
            {
                // Set Reservation Informations
                transactionId = transactionId,
                travellers = new SetReservationRequest.Traveller[]
                {
                    new SetReservationRequest.Traveller(FistName,LastName,Email)
                }
            };

            #endregion

            //Api Url for post
            var addurl = "api/bookingservice/setreservationinfo";

            // Post to Api and Get Response
            var response = await _apiService.Post(reservationRequest, addurl);

            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                SetReservationResponse.Rootobject deserializedJson = JsonConvert.DeserializeObject<SetReservationResponse.Rootobject>(id);
                reservation = new Reservation
                {
                    HotelName = deserializedJson.body.reservationData.services[0].serviceDetails.hotelDetail.name,
                    TotalPrice = deserializedJson.body.reservationData.services[0].price.amount,
                    BeginDate = deserializedJson.body.reservationData.services[0].beginDate,
                    EndDate = deserializedJson.body.reservationData.services[0].endDate,
                    Adult = deserializedJson.body.reservationData.services[0].adult,
                    Room = deserializedJson.body.reservationData.services[0].serviceDetails.room,
                    Night = deserializedJson.body.reservationData.services[0].serviceDetails.night,
                    TravallerName = FistName,
                    TravallerSurname = LastName,
                    TravallerEmail = Email,
                    TransactionId = transactionId
                };
                
            }
            return reservation;

        }
    }
}
