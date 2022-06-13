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
        private readonly IUnitOfWork _unitOfWork;

        public SetReservationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Reservation> SetReservation(string FistName, string LastName, string Email, string transactionId)
        {
            Reservation reservation = new Reservation();

            //Token for header from database
            var tokentype = _unitOfWork.Authentication.GetById();
            var token = tokentype.Token;

            //Url for post api
            var url = "http://service.stage.paximum.com/v2/api/bookingservice/setreservationinfo";
            var jsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            //Post with httpclient
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetReservationRequest.Rootobject reservationRequest = new SetReservationRequest.Rootobject()
            {
                // Set Reservation Informations
                transactionId = transactionId,
                travellers = new SetReservationRequest.Traveller[]
                {
                    new SetReservationRequest.Traveller()
                    {
                        name=FistName,
                        surname=LastName,
                        address= new SetReservationRequest.Address
                        {
                            email=Email
                        }
                    }
                    
                    
                }
            };



            var response = await httpClient.PostAsJsonAsync(url, reservationRequest);
            //If response is success filter for Hotel Details an Price
            if (response.IsSuccessStatusCode)
            {
                var id = await response.Content.ReadAsStringAsync();
                SetReservationResponse.Rootobject deserializedJson = JsonConvert.DeserializeObject<SetReservationResponse.Rootobject>(id);
                reservation.HotelName= deserializedJson.body.reservationData.services[0].serviceDetails.hotelDetail.name;
                reservation.TotalPrice = deserializedJson.body.reservationData.services[0].price.amount;
                reservation.BeginDate = deserializedJson.body.reservationData.services[0].beginDate;
                reservation.EndDate = deserializedJson.body.reservationData.services[0].endDate;
                reservation.Adult = deserializedJson.body.reservationData.services[0].adult;
                reservation.Room = deserializedJson.body.reservationData.services[0].serviceDetails.room;
                reservation.Night = deserializedJson.body.reservationData.services[0].serviceDetails.night;
                reservation.TravallerName = FistName;
                reservation.TravallerSurname = LastName;
                reservation.TravallerEmail = Email;
                reservation.TransactionId = transactionId;
            }
            return reservation;

        }
    }
}
